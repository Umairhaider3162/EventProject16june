using Dapper;
using EventFinal.Models;
using Microsoft.Data.SqlClient;

namespace EventFinal.Repositories
{
    public class DropdownCommonRepository: BaseRepository, IDropdownCommonRepository
    {
        public DropdownCommonRepository(IConfiguration configuration) : base(configuration) { }
        IEnumerable<Country> IDropdownCommonRepository.GetCountry()
        {
            try
            {
                using (var connection = Connect())
                {
                    var query = "select * from Country";
                    var countries = connection.Query<Country>(query);
                    return countries;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
      IEnumerable<States> IDropdownCommonRepository.GetStatebyID(int id)
        {
            try
            {
                using (var connection = Connect())
                {
                    var query = "select * from States where CountryID=@CountryID";
                    var states = connection.Query<States>(query, new { id });
                    
                    return states;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        IEnumerable<City> IDropdownCommonRepository.GetCitybyID(int id)
        {
            try
            {
                using(var connection = Connect())
                {
                    var query = "select * from City where StateID=@StateID";
                    var citys = connection.Query<City>(query, new { id });
                    return citys;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
