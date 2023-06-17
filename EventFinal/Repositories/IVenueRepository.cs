using EventFinal.Models;
using EventFinal.ViewModel;
namespace EventFinal.Repositories
{
    public interface IVenueRepository
    {
        Task<Venue> SaveVenueAsync(Venue venue);
        IEnumerable<Venue> GetVenues();
        Venue GetVenueById(int id);
    }
}
