﻿using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        System.Threading.Tasks.Task AddEquipmentAsync(Equipment equipment);
        Task<IEnumerable<Equipment>> GetEquipmentByProjectIdAsync(int projectId);
        System.Threading.Tasks.Task UpdateEquipmentConditionAsync(int equipmentId, string condition);
    }
}
