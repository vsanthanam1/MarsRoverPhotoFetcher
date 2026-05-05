using System.Text.Json.Serialization;

namespace MarsRoverPhotoFetcher.Models
{
    public class MarsRoverPhotosResponse
    {
        [JsonPropertyName("photos")]
        public List<MarsRoverPhoto> Photos { get; set; }
    }

}
