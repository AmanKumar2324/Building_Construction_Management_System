using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        Task AddMaterialAsync(Material material);
        Task UpdateMaterialStatusAsync(int materialId, string status);
        //Task<IEnumerable<Material>> GetMaterialsByProjectIdAsync(int projectId);
    }
}
