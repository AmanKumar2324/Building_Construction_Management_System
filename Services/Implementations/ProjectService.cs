﻿using Building_Construction_Management_System.Models;
using Building_Construction_Management_System.DTOs;
using Building_Construction_Management_System.Repositories.Interfaces;
using Building_Construction_Management_System.Services.Interfaces;
using Building_Construction_Management_System.Dtos;

namespace Building_Construction_Management_System.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _projectRepository.GetProjectsAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await _projectRepository.GetProjectByIdAsync(projectId);
        }

        //public async System.Threading.Tasks.Task AddProjectAsync(Project project)
        //{
        //    if (string.IsNullOrWhiteSpace(project.Name) || project.Budget <= 0)
        //    {
        //        throw new ArgumentException("Project name and budget are required.");
        //    }

        //    await _projectRepository.AddProjectAsync(project);
        //    await _unitOfWork.SaveChangesAsync();
        //}
        public async System.Threading.Tasks.Task AddProjectAsync(Project project)
        {
            // Validate Project Manager ID
            var manager = await _userRepository.GetUserByRoleUserIdAsync(project.ProjectManagerId);
            if (manager == null)
            {
                throw new ArgumentException("Invalid Project Manager ID.");
            }

            // Add Project
            await _projectRepository.AddProjectAsync(project);
            await _unitOfWork.SaveChangesAsync();
        }


        public async System.Threading.Tasks.Task UpdateProjectAsync(Project project)
        {
            if (project.ProjectId <= 0)
            {
                throw new ArgumentException("Invalid project ID.");
            }

            // Ensure the ProjectManagerId is valid
            var manager = await _userRepository.GetUserByRoleUserIdAsync(project.ProjectManagerId);
            if (manager == null)
            {
                throw new ArgumentException("Invalid Project Manager ID.");
            }

            await _projectRepository.UpdateProjectAsync(project);
            await _unitOfWork.SaveChangesAsync();
        }


        public async System.Threading.Tasks.Task DeleteProjectAsync(int projectId)
        {
            if (projectId <= 0)
            {
                throw new ArgumentException("Invalid project ID.");
            }

            await _projectRepository.DeleteProjectAsync(projectId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BudgetReportDTO>> GetBudgetReportAsync()
        {
            return await _projectRepository.GetBudgetReportAsync();
        }

        public async Task<IEnumerable<ProjectProgressDTO>> GetProjectProgressReportAsync(int projectId)
        {
            return await _projectRepository.GetProjectProgressReportAsync(projectId);
        }
        public async Task<IEnumerable<ProjectStatusDto>> GetProjectStatusesAsync()
        {
            return await _projectRepository.GetProjectStatusesAsync();
        }

    }
}
