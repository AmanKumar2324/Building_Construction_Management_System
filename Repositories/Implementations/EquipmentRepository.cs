using Microsoft.EntityFrameworkCore;
using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Data;

namespace Building_Construction_Management_System.Repositories.Implementations
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly BuildingConstructionDbContext _context;

        public EquipmentRepository(BuildingConstructionDbContext context)
        {
            _context = context;
        }

        public async Task AddEquipmentAsync(Equipment equipment)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC AddEquipment @ProjectId={equipment.ProjectId}, @EquipmentName={equipment.EquipmentName}, @Condition={equipment.Condition}, @MaintenanceSchedule={equipment.MaintenanceSchedule}, @UsageLogs={equipment.UsageLogs}");
        }

        public async Task<IEnumerable<Equipment>> GetEquipmentByProjectIdAsync(int projectId)
        {
            return await _context.Equipments
                .FromSqlInterpolated($"EXEC GetEquipmentByProject @ProjectId={projectId}")
                .ToListAsync();
        }

        public async Task UpdateEquipmentConditionAsync(int equipmentId, string condition)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC UpdateEquipmentCondition @EquipmentId={equipmentId}, @Condition={condition}");
        }
    }
}
