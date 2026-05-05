using System.Text.Json.Serialization;

namespace MarsRoverPhotoFetcher.Models
{
    public class MarsRoverPhoto
    {
        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("sol")]

        public int Sol { get; set; }

        [JsonPropertyName("camera")]

        public MarsRoverCamera Camera { get; set; }

        [JsonPropertyName("img_src")]
        public string Img_Src { get; set; }

        [JsonPropertyName("earth_date")]
        public string Earth_Date { get; set; }

        [JsonPropertyName("rover")]
        public MarsRoverInfo Rover { get; set; }
    }



}
