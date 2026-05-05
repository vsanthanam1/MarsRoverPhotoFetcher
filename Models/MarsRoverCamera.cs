using System.Text.Json.Serialization;

namespace MarsRoverPhotoFetcher.Models
{
    public class MarsRoverCamera
    {
        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name { get; set; }

        [JsonPropertyName("rover_id")]
        public int Rover_Id { get; set; }

        [JsonPropertyName("full_name")]
        public string Full_Name { get; set; }
    }


}
