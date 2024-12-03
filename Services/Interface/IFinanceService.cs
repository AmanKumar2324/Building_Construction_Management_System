using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IFinanceService
    {
        System.Threading.Tasks.Task AddFinanceAsync(Finance finance);
        Task<IEnumerable<Finance>> GetFinanceByProjectIdAsync(int projectId);
    }
}
