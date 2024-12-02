using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int projectId);
        Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync();
        Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId);
    }
}
