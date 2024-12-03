using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        System.Threading.Tasks.Task AddProjectAsync(Project project);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<IEnumerable<Project>> GetProjectsAsync();
        System.Threading.Tasks.Task UpdateProjectAsync(Project project);
        System.Threading.Tasks.Task DeleteProjectAsync(int projectId);
        Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync();
        Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId);
    }
}
