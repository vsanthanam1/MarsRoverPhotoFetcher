using MarsRoverPhotoFetcher.Models;

namespace MarsRoverPhotoFetcher.Services.Interfaces
{
    public interface INasaMarsRoverClient
    {
        Task<List<MarsRoverPhoto>> GetPhotosByEarthDateAsync(DateTime date);
    }

}
