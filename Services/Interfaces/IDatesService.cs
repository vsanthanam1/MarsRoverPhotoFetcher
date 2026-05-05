namespace MarsRoverPhotoFetcher.Services.Interfaces
{
    public interface IDatesService
    {
        Task<List<DateTime>> GetDatesAsync();
    }

}
