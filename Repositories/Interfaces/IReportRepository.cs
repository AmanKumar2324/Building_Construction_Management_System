using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task AddReportAsync(Report report);
        Task<IEnumerable<Report>> GetReportsByProjectIdAsync(int projectId);
    }
}
