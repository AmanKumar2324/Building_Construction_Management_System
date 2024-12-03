using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public MaterialRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddMaterialAsync(Material material)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddMaterial @ProjectId={material.ProjectId}, @MaterialName={material.MaterialName}, @Quantity={material.Quantity}, @SupplierId={material.SupplierId}, @Cost={material.Cost}, @Status={material.Status}");
        }

        public async System.Threading.Tasks.Task UpdateMaterialStatusAsync(int materialId, string status)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateMaterialStatus @MaterialId={materialId}, @Status={status}");
        }

        //public async Task<IEnumerable<Material>> GetMaterialsByProjectIdAsync(int projectId)
        //{
        //    return await _context.Materials
        //        .FromSqlInterpolated($"EXEC GetMaterialsByProjectId @ProjectId={projectId}")
        //        .ToListAsync();
        //}
    }
}
