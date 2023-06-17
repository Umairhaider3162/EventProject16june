using Dapper;
using EventFinal.Models;
using Microsoft.Data.SqlClient;

namespace EventFinal.Repositories
{
    public class EquipmentRepository:BaseRepository,IEquipmentRepository
    {
        public EquipmentRepository(IConfiguration configuration): base(configuration) { }

        public async Task<Equipment> AddEquipmentAsync (Equipment equipment)
        {
            var query = "INSERT INTO Equipment (EquipmentName, EquipmentCost, EquipmentFilename,EquipmentFilePath,Createdby,Createdate) VALUES (@EquipmentName, @EquipmentCost, @EquipmentFilename,@EquipmentFilePath,@Createdby,@Createdate)" +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameter = new DynamicParameters();
             parameter.Add("@EquipmentName", equipment.EquipmentName);
            parameter.Add("@EquipmentCost", equipment.EquipmentCost);
            parameter.Add("@EquipmentFilename", equipment.EquipmentFilename);
            parameter.Add("@EquipmentFilePath", equipment.EquipmentFilePath);
            parameter.Add("@Createdby", equipment.Createdby);
            parameter.Add("@Createdate", equipment.Createdate);
            using (var connection = Connect())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameter);
                var createEquipment = new Equipment
                {
                    EquipmentID = id,
                    EquipmentName = equipment.EquipmentName,
                };
                return createEquipment;
            }
        }
        public IEnumerable <Equipment> ShowEquipmment ()
        {
               using (var connection = Connect())
            {
                var query = "select * from Equipment";
                    IEnumerable <Equipment> equipment = connection.Query<Equipment>(query);
                return equipment;
            }
        }

        public Equipment GetEquipmentById(int id)
        {
            using(var connection = Connect())
            {
                var query = "select * from Equipment where EquipmentID=@Id";
                Equipment equipment = connection.QuerySingle<Equipment>(query, new {id});
                return equipment;
                  
            }
        }

    }
}
