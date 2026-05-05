using MarsRoverPhotoFetcher.Models;

namespace MarsRoverPhotoFetcher.Services.Interfaces
{
    public interface IRoverJobService
    {
        Task<List<RoverRunResultDto>> RunAsync();
    }

}
