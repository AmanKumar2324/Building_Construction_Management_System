using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.DTOs;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
        Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync();
        Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId);
    }
}
