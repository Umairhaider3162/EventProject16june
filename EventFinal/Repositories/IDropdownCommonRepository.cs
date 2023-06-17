using EventFinal.Models;
namespace EventFinal.Repositories
{
    public interface IDropdownCommonRepository
    {
        IEnumerable<Country> GetCountry();
        IEnumerable<States> GetStatebyID(int ID);
        IEnumerable<City> GetCitybyID(int ID);
    }
}
