using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interface;
using Building_Construction_Management_System.Services.Interfaces;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VendorService(IVendorRepository vendorRepository, IUnitOfWork unitOfWork)
        {
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            return await _vendorRepository.GetVendorsAsync();
        }

        public async System.Threading.Tasks.Task AddVendorAsync(Vendor vendor)
        {
            if (string.IsNullOrWhiteSpace(vendor.Name))
            {
                throw new ArgumentException("Vendor name is required.");
            }

            await _vendorRepository.AddVendorAsync(vendor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveVendorAsync(int vendorId)
        {
            if (vendorId <= 0)
            {
                throw new ArgumentException("Invalid vendor ID.");
            }

            await _vendorRepository.RemoveVendorAsync(vendorId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateVendorStatusAsync(int vendorId, string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status is required.");
            }

            await _vendorRepository.UpdateVendorStatusAsync(vendorId, status);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
