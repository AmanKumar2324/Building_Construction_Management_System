using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class FinanceRepository :IFinanceRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public FinanceRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddFinanceAsync(Finance finance)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddFinance @ProjectId={finance.ProjectId}, @ExpenseType={finance.ExpenseType}, @Amount={finance.Amount}, @Date={finance.Date}, @PaymentStatus={finance.PaymentStatus}");
        }

        public async Task<IEnumerable<Finance>> GetFinanceByProjectIdAsync(int projectId)
        {
            return await _context.Finances
                .FromSqlInterpolated($"EXEC GetFinanceByProject @ProjectId={projectId}")
                .ToListAsync();
        }
    }
}
