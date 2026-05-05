using System.Text.Json.Serialization;

namespace MarsRoverPhotoFetcher.Models
{
    public class MarsRoverInfo
    {
        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name { get; set; }

        [JsonPropertyName("landing_date")]
        public string Landing_Date { get; set; }

        [JsonPropertyName("launch_date")]
        public string Launch_Date { get; set; }

        [JsonPropertyName("status")]

        public string Status { get; set; }
    }



}
