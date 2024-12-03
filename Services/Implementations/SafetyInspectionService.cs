using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class SafetyInspectionService : ISafetyInspectionService
    {
        private readonly ISafetyInspectionRepository _safetyInspectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SafetyInspectionService(ISafetyInspectionRepository safetyInspectionRepository, IUnitOfWork unitOfWork)
        {
            _safetyInspectionRepository = safetyInspectionRepository;
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task AddSafetyInspectionAsync(SafetyInspection inspection)
        {
            if (inspection.InspectionDate == default)
            {
                throw new ArgumentException("Inspection date is required.");
            }

            await _safetyInspectionRepository.AddSafetyInspectionAsync(inspection);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<SafetyInspection>> GetSafetyInspectionsByProjectAsync(int projectId)
        {
            if (projectId <= 0)
            {
                throw new ArgumentException("Invalid project ID.");
            }

            try
            {
                var inspections = await _safetyInspectionRepository.GetSafetyInspectionsByProjectAsync(projectId);
                return inspections;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException("An error occurred while retrieving safety inspections.", ex);
            }
        }
    }
}
