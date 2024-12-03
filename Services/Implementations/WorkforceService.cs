using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class WorkforceService : IWorkforceService
    {
        private readonly IWorkforceRepository _workforceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkforceService(IWorkforceRepository workforceRepository, IUnitOfWork unitOfWork)
        {
            _workforceRepository = workforceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Workforce>> GetWorkforceByProjectIdAsync(int projectId)
        {
            return await _workforceRepository.GetWorkforceByProjectIdAsync(projectId);
        }

        public async Task AddWorkforceAsync(Workforce workforce)
        {
            if (string.IsNullOrWhiteSpace(workforce.Role))
            {
                throw new ArgumentException("Role is required.");
            }

            await _workforceRepository.AddWorkforceAsync(workforce);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateWorkforceAsync(int workerId, string role, string attendanceStatus, decimal performanceRating)
        {
            // Input validation (optional)
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Role is required.");
            }

            if (string.IsNullOrWhiteSpace(attendanceStatus))
            {
                throw new ArgumentException("Attendance Status is required.");
            }

            // Call the repository method to execute the stored procedure and update the workforce
            try
            {
                await _workforceRepository.UpdateWorkforceAsync(workerId, role, attendanceStatus, performanceRating);
                await _unitOfWork.SaveChangesAsync(); // Ensure changes are committed to the database
            }
            catch (Exception ex)
            {
                // Log or handle the exception as necessary
                throw new InvalidOperationException("An error occurred while updating the workforce.", ex);
            }
        }
    }
}
