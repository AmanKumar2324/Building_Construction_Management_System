using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public ReportRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddReportAsync(Report report)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddReport @ProjectId={report.ProjectId}, @ReportType={report.ReportType}, @GeneratedDate={report.GeneratedDate}, @Data={report.Data}, @CreatedBy={report.CreatedBy}");
        }

        public async Task<IEnumerable<Report>> GetReportsByProjectIdAsync(int projectId)
        {
            return await _context.Reports
                .FromSqlInterpolated($"EXEC GetReportsByProject @ProjectId={projectId}")
                .ToListAsync();
        }
    }
}
