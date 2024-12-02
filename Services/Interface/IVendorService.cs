using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IVendorService
    {
        Task AddVendorAsync(Vendor vendor);
        Task<IEnumerable<Vendor>> GetVendorsAsync();
        Task RemoveVendorAsync(int vendorId);
        Task UpdateVendorStatusAsync(int vendorId, string status);
    }
}
