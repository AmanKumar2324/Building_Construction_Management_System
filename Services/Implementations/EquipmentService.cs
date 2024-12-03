using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentService(IEquipmentRepository equipmentRepository, IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentByProjectIdAsync(int projectId)
        {
            return await _equipmentRepository.GetEquipmentByProjectIdAsync(projectId);
        }

        public async Task AddEquipmentAsync(Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(equipment.EquipmentName))
            {
                throw new ArgumentException("Equipment name is required.");
            }

            await _equipmentRepository.AddEquipmentAsync(equipment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateEquipmentConditionAsync(int equipmentId, string condition)
        {
            if (string.IsNullOrWhiteSpace(condition))
            {
                throw new ArgumentException("Condition is required.");
            }

            await _equipmentRepository.UpdateEquipmentConditionAsync(equipmentId, condition);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
