using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _financeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinanceService(IFinanceRepository financeRepository, IUnitOfWork unitOfWork)
        {
            _financeRepository = financeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Finance>> GetFinanceByProjectIdAsync(int projectId)
        {
            return await _financeRepository.GetFinanceByProjectIdAsync(projectId);
        }

        public async Task AddFinanceAsync(Finance finance)
        {
            if (finance.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            await _financeRepository.AddFinanceAsync(finance);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
