using MarsRoverPhotoFetcher.Models;
using MarsRoverPhotoFetcher.Services.Interfaces;

namespace MarsRoverPhotoFetcher.Services.Implementations
{
    public class RoverJobService : IRoverJobService
    {
        private readonly IDatesService _datesService;
        private readonly INasaMarsRoverClient _nasaClient;
        private readonly IRoverImageDownloader _downloader;
        private readonly ILogger<RoverJobService> _logger;

        public RoverJobService(IDatesService datesService, INasaMarsRoverClient nasaClient, IRoverImageDownloader downloader,
            ILogger<RoverJobService> logger)
        {
            _datesService = datesService;
            _nasaClient = nasaClient;
            _downloader = downloader;
            _logger = logger;
        }

        public async Task<List<RoverRunResultDto>> RunAsync()
        {
            var dates = await _datesService.GetDatesAsync();
            var results = new List<RoverRunResultDto>();

            foreach (var date in dates)
            {
                var result = new RoverRunResultDto { Date = date };

                try
                {
                    var photos = await _nasaClient.GetPhotosByEarthDateAsync(date);
                    result.TotalPhotosFromApi = photos.Count;

                    result.DownloadedCount = await _downloader.DownloadImagesAsync(date, photos);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing date {Date}", date);
                    result.Error = ex.Message;
                }

                results.Add(result);
            }

            return results;
        }
    }

}
