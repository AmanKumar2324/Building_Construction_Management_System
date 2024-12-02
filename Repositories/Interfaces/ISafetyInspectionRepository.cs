using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface ISafetyInspectionRepository
    {
        Task AddSafetyInspectionAsync(SafetyInspection inspection);
        Task<IEnumerable<SafetyInspection>> GetSafetyInspectionsByProjectAsync(int projectId);
    }
}
