using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IFinanceRepository
    {
        System.Threading.Tasks.Task AddFinanceAsync(Finance finance);
        Task<IEnumerable<Finance>> GetFinanceByProjectIdAsync(int projectId);
    }
}
