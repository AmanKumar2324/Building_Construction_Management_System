using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task AddEquipmentAsync(Equipment equipment);
        Task<IEnumerable<Equipment>> GetEquipmentByProjectIdAsync(int projectId);
        Task UpdateEquipmentConditionAsync(int equipmentId, string condition);
    }
}
