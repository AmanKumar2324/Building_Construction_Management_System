using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IReportService
    {
        System.Threading.Tasks.Task AddReportAsync(Report report);
        Task<IEnumerable<Report>> GetReportsByProjectIdAsync(int projectId);
    }
}
