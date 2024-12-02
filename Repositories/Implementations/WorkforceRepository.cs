using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class WorkforceRepository : IWorkforceRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public WorkforceRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddWorkforceAsync(Workforce workforce)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddWorkforce @ProjectId={workforce.ProjectId}, @TaskId={workforce.TaskId}, @Role={workforce.Role}, @AttendanceStatus={workforce.AttendanceStatus}, @PerformanceRating={workforce.PerformanceRating}");
        }

        public async Task<IEnumerable<Workforce>> GetWorkforceByProjectIdAsync(int projectId)
        {
            return await _context.Workforces
                .FromSqlInterpolated($"EXEC GetWorkforceByProjectId @ProjectId={projectId}")
                .ToListAsync();
        }
        public async Task UpdateWorkforceAsync(int workerId, string role, string attendanceStatus, decimal performanceRating)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateWorkforce @WorkerId={workerId}, @Role={role}, @AttendanceStatus={attendanceStatus}, @PerformanceRating={performanceRating}");
        }

    }
}
