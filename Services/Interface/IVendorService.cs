using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IVendorService
    {
        System.Threading.Tasks.Task AddVendorAsync(Vendor vendor);
        Task<IEnumerable<Vendor>> GetVendorsAsync();
        System.Threading.Tasks.Task RemoveVendorAsync(int vendorId);
        System.Threading.Tasks.Task UpdateVendorStatusAsync(int vendorId, string status);
    }
}
