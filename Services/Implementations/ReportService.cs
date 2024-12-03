using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IReportRepository reportRepository, IUnitOfWork unitOfWork)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Report>> GetReportsByProjectIdAsync(int projectId)
        {
            return await _reportRepository.GetReportsByProjectIdAsync(projectId);
        }

        public async System.Threading.Tasks.Task AddReportAsync(Report report)
        {
            if (string.IsNullOrWhiteSpace(report.ReportType))
            {
                throw new ArgumentException("Report type is required.");
            }

            await _reportRepository.AddReportAsync(report);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
