namespace MarsRoverPhotoFetcher.Models
{
    public class RoverPhotoDto
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public DateTime EarthDate { get; set; }
        public string ImageUrl { get; set; }
        public string CameraName { get; set; }
        public string CameraFullName { get; set; }
        public string RoverName { get; set; }
    }

}
