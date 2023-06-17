using Dapper;
using EventFinal.Models;
using Microsoft.Data.SqlClient;

namespace EventFinal.Repositories
{
    public class VenueRepository:BaseRepository,IVenueRepository
    {
        public VenueRepository(IConfiguration configuration): base(configuration) { }

        public async Task<Venue> SaveVenueAsync(Venue venue)
        {
            var query = "INSERT INTO Venue (VenueName, VenueCost, VenueFilename,VenueFilePath,Createdby,Createdate) VALUES (@VenueName, @VenueCost, @VenueFilename,@VenueFilePath,@Createdby,@Createdate)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameter = new DynamicParameters();
           
            parameter.Add("@VenueName", venue.VenueName);
            parameter.Add("@VenueCost", venue.VenueCost);
            parameter.Add("@VenueFilename", venue.VenueFilename);
            parameter.Add("@VenueFilePath", venue.VenueFilePath);
            parameter.Add("@Createdby", venue.Createdby);
            parameter.Add("@Createdate", DateTime.Now);
            using (var connection = Connect())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameter);
                var createdVenue = new Venue
                {
                    VenueID = id,
                    VenueName = venue.VenueName,
                };
                return createdVenue;    
            }
        }

        public IEnumerable<Venue> GetVenues()
        {
            using(var connection = Connect())
            {
                var query = "select * from Venue";
                IEnumerable<Venue> venues = connection.Query<Venue>(query);
                return venues;  
            }
        }

        public Venue GetVenueById(int id)
        {
            using(var connection = Connect())
            {
                var query = "select * from Venue where VenueID=@Id";
                    Venue venue = connection.QuerySingle<Venue>(query, new {id});
                return venue;
            }
        }
    }
}
