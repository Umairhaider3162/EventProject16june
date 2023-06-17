using EventFinal.Models;
namespace EventFinal.Repositories
{
    public interface IEquipmentRepository
    {
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
        IEnumerable<Equipment> ShowEquipmment();
        Equipment GetEquipmentById(int id);
    }
}
