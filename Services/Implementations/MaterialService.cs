using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(IMaterialRepository materialRepository, IUnitOfWork unitOfWork)
        {
            _materialRepository = materialRepository;
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<Material>> GetMaterialsByProjectIdAsync(int projectId)
        //{
        //    return await _materialRepository.GetMaterialsByProjectIdAsync(projectId);
        //}

        public async Task AddMaterialAsync(Material material)
        {
            if (string.IsNullOrWhiteSpace(material.MaterialName))
            {
                throw new ArgumentException("Material name is required.");
            }

            await _materialRepository.AddMaterialAsync(material);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateMaterialStatusAsync(int materialId, string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status is required.");
            }

            await _materialRepository.UpdateMaterialStatusAsync(materialId, status);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
