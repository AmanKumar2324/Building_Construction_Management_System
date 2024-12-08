using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Dtos;

namespace Building_Construction_Management_System.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int projectId);
        System.Threading.Tasks.Task AddProjectAsync(Project project);
        System.Threading.Tasks.Task UpdateProjectAsync(Project project);
        System.Threading.Tasks.Task DeleteProjectAsync(int projectId);
        Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync();
        Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId);
        Task<IEnumerable<ProjectStatusDto>> GetProjectStatusesAsync();
    }
}
