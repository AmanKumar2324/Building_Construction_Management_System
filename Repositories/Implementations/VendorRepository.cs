﻿using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class VendorRepository :IVendorRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public VendorRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddVendor @Name={vendor.Name}, @ContactDetails={vendor.ContactDetails}, @MaterialSupplied={vendor.MaterialSupplied}, @ContractTerms={vendor.ContractTerms}, @DeliveryStatus={vendor.DeliveryStatus}");
        }

        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            return await _context.Vendors
                .FromSqlInterpolated($"EXEC GetVendors")
                .ToListAsync();
        }

        public async Task RemoveVendorAsync(int vendorId)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC RemoveVendors @VendorId={vendorId}");
        }

        public async Task UpdateVendorStatusAsync(int vendorId, string status)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateVendorStatus @VendorId={vendorId}, @Status={status}");
        }
    }
}
