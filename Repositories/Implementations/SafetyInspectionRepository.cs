using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class SafetyInspectionRepository :ISafetyInspectionRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public SafetyInspectionRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddSafetyInspectionAsync(SafetyInspection inspection)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddSafetyInspection @ProjectId={inspection.ProjectId}, @SupervisorId={inspection.SupervisorId}, @InspectionDate={inspection.InspectionDate}, @Findings={inspection.Findings}, @CorrectiveAction={inspection.CorrectiveAction}");
        }
        public async Task<IEnumerable<SafetyInspection>> GetSafetyInspectionsByProjectAsync(int projectId)
        {
            return await _context.SafetyInspections
            .FromSqlInterpolated($"EXEC GetSafetyInspectionsByProject @ProjectId={projectId}")
            .ToListAsync();
        }
    }
}
