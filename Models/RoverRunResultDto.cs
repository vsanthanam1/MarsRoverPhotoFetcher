namespace MarsRoverPhotoFetcher.Models
{
    public class RoverRunResultDto
    {
        public DateTime Date { get; set; }
        public int TotalPhotosFromApi { get; set; }
        public int DownloadedCount { get; set; }
        public string? Error { get; set; }
    }
}
