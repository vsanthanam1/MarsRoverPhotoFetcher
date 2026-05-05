namespace MarsRoverPhotoFetcher.Models
{
    public class NasaOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = "https://api.nasa.gov";
        public string RoverName { get; set; } = "curiosity";
    }

}
