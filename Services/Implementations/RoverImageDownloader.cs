using MarsRoverPhotoFetcher.Models;
using MarsRoverPhotoFetcher.Services.Interfaces;

namespace MarsRoverPhotoFetcher.Services.Implementations
{
    public class RoverImageDownloader : IRoverImageDownloader
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoverImageDownloader> _logger;
        private readonly IWebHostEnvironment _env;

        public RoverImageDownloader(
            HttpClient httpClient,
            ILogger<RoverImageDownloader> logger,
            IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _logger = logger;
            _env = env;
        }

        public async Task<int> DownloadImagesAsync(DateTime date, IEnumerable<MarsRoverPhoto> photos)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var rootPhotosPath = Path.Combine(_env.ContentRootPath, "photos", dateString);

            Directory.CreateDirectory(rootPhotosPath);

            var downloadedCount = 0;

            foreach (var photo in photos.Take(5))
            {
                if (string.IsNullOrWhiteSpace(photo.Img_Src))
                    continue;

                var uri = new Uri(photo.Img_Src);
                var fileName = Path.GetFileName(uri.LocalPath);
                var localPath = Path.Combine(rootPhotosPath, fileName);

                if (File.Exists(localPath))
                {
                    _logger.LogInformation("Skipping existing image: {Path}", localPath);
                    continue;
                }

                try
                {
                    _logger.LogInformation("Downloading image {Url} to {Path}", photo.Img_Src, localPath);

                    using var stream = await _httpClient.GetStreamAsync(photo.Img_Src);
                    using var fileStream = File.Create(localPath);
                    await stream.CopyToAsync(fileStream);

                    downloadedCount++;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to download image {Url}", photo.Img_Src);
                }
            }

            return downloadedCount;
        }
    }

}
