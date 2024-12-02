﻿using Building_Construction_Management_System.Models;

namespace Building_Construction_Management_System.Services.Interface
{
    public interface IWorkforceService
    {
        Task AddWorkforceAsync(Workforce workforce);
        Task<IEnumerable<Workforce>> GetWorkforceByProjectIdAsync(int projectId);
        Task UpdateWorkforceAsync(int workerId, string role, string attendanceStatus, decimal performanceRating);
    }
}
