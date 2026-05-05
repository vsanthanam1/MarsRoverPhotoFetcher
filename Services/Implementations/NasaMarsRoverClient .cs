using MarsRoverPhotoFetcher.Models;
using MarsRoverPhotoFetcher.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MarsRoverPhotoFetcher.Services.Implementations
{
    public class NasaMarsRoverClient : INasaMarsRoverClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NasaMarsRoverClient> _logger;
        private readonly NasaOptions _options;
        private readonly IWebHostEnvironment _env;

        public NasaMarsRoverClient(
            HttpClient httpClient,
            ILogger<NasaMarsRoverClient> logger,
            IOptions<NasaOptions> options,
            IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _logger = logger;
            _options = options.Value;
            _env = env;
        }

        public async Task<List<MarsRoverPhoto>> GetPhotosByEarthDateAsync(DateTime date)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var url =
                $"{_options.BaseUrl}/mars-photos/api/v1/rovers/{_options.RoverName}/photos" +
                $"?earth_date={dateString}&api_key={_options.ApiKey}";

            _logger.LogInformation("Calling NASA API for date {Date}: {Url}", dateString, url);

            try
            {
                using var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("NASA API returned {StatusCode} for {Date}. Falling back to mock data.",
                        response.StatusCode, dateString);
                    return await GetFromMockAsync(date);
                }

                var json = await response.Content.ReadAsStringAsync();

                var nasaResponse = JsonSerializer.Deserialize<MarsRoverPhotosResponse>(json);

                if (nasaResponse?.Photos == null)
                {
                    _logger.LogWarning("NASA API response has null Photos for {Date}. Falling back to mock data.", dateString);
                    return await GetFromMockAsync(date);
                }

                return nasaResponse.Photos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling NASA API for {Date}. Falling back to mock data.", dateString);
                return await GetFromMockAsync(date);
            }
        }

        private async Task<List<MarsRoverPhoto>> GetFromMockAsync(DateTime date)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data/sample-rover-response.json");

            if (!File.Exists(filePath))
            {
                _logger.LogError("Mock JSON file not found at {Path}", filePath);
                return new List<MarsRoverPhoto>();
            }

            var json = await File.ReadAllTextAsync(filePath);

            var nasaResponse = JsonSerializer.Deserialize<MarsRoverPhotosResponse>(json);

            if (nasaResponse?.Photos == null)
            {
                _logger.LogError("Mock JSON has null Photos");
                return new List<MarsRoverPhoto>();
            }

            var dateString = date.ToString("yyyy-MM-dd");

            return nasaResponse.Photos
                .Where(p => p.Earth_Date == dateString)
                .ToList();
        }
    }

}
