using Building_Construction_Management_System.Data;
using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public ProjectRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddProjectAsync(Project project)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddProject @Name={project.Name}, @Location={project.Location}, @StartDate={project.StartDate}, @EndDate={project.EndDate}, @Budget={project.Budget}, @Status={project.Status}, @ProjectManagerId={project.ProjectManagerId}");
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateProjectAsync(Project project)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateProject @ProjectId={project.ProjectId}, @Name={project.Name}, @Location={project.Location}, @StartDate={project.StartDate}, @EndDate={project.EndDate}, @Budget={project.Budget}, @Status={project.Status}");
        }

        public async System.Threading.Tasks.Task DeleteProjectAsync(int projectId)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteProject @ProjectId={projectId}");
        }

        public async Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync()
        {
            return await _context.Set<BudgetReportDTO>()
                .FromSqlInterpolated($"EXEC GetBudgetReport")
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId)
        {
            return await _context.Set<ProjectProgressDTO>()
                .FromSqlInterpolated($"EXEC GetProjectProgressReport @ProjectId={projectId}")
                .ToListAsync();
        }
    }
}
