using Dapper;
using EventFinal.Models;

namespace EventFinal.Repositories
{
    public class FlowerRepository:BaseRepository,IflowerRepository
    {
        public FlowerRepository(IConfiguration configuration): base(configuration)
        { }

        public async Task<Flower> AddFlowerAsync( Flower flower)
        {
            var query = "INSERT INTO Flower (FlowerName, FlowerCost, FlowerFilename,FlowerFilePath,Createdby,Createdate) VALUES (@FlowerName, @FlowerCost, @FlowerFilename,@FlowerFilePath,@Createdby,@Createdate)" +
                     "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("@FlowerName", flower.FlowerName);
            parameters.Add("@FlowerCost", flower.FlowerCost);
            parameters.Add("@FlowerFilename", flower.FlowerFilename);
            parameters.Add("@FlowerFilePath", flower.FlowerFilePath);
            parameters.Add("@Createdby", flower.Createdby);
            parameters.Add("@Createdate", flower.Createdate);
            using(var connection = Connect())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var AddFlower = new Flower
                {
                    FlowerID = id,
                    FlowerName = flower.FlowerName,
                };
                return AddFlower;
            }
        }
    }
}
