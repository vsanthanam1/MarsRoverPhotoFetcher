using MarsRoverPhotoFetcher.Models;

namespace MarsRoverPhotoFetcher.Services.Interfaces
{
    public interface IRoverImageDownloader
    {
        Task<int> DownloadImagesAsync(DateTime date, IEnumerable<MarsRoverPhoto> photos);
    }

}
