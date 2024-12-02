using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface IMaterialService
    {
        //Task<IEnumerable<Material>> GetMaterialsByProjectIdAsync(int projectId);
        Task AddMaterialAsync(Material material);
        Task UpdateMaterialStatusAsync(int materialId, string status);
    }
}
