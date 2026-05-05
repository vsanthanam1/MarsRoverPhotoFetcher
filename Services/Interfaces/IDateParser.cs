namespace MarsRoverPhotoFetcher.Services.Interfaces
{
    public interface IDateParser
    {
        string? Normalize(string rawDate);
    }
}
