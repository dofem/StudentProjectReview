using Microsoft.AspNetCore.Mvc;
using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Model.Enum;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Service.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> DeleteProject(int id)
        {
            var project =  _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (project == null)
            {
                return null;
            }
            _context.Remove(project);
            return project;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return _context.Projects.ToList();
            
        }

        public async Task<Project> GetProjectById(int id)
        {
            return  _context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task<Project> UpdateProject(int id,Project project)
        {
           var existingproject = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (existingproject == null) { return null; }
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return existingproject;

            
        }

        public async Task<Project> AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            project.CurrentStatus = CurrentStatus.SubmittedForReview.ToString();
            project.ActionNeeded = ActionNeeded.SupervisorPending.ToString();
            project.IsReviewed = Answer.No.ToString();
            await _context.SaveChangesAsync();
            return project;

        }

        public async Task<List<Project>> GetAllProjectForSupervisorApproval()
        {
            return _context.Projects.Where(u=> u.CurrentStatus==CurrentStatus.SubmittedForReview.ToString() && u.ActionNeeded == ActionNeeded.SupervisorPending.ToString()).ToList();
        }

        public async Task<Project> GetProjectForSupervisorApproval(int id)
        {
            return _context.Projects.Where(u => u.Id == id && u.CurrentStatus == CurrentStatus.SubmittedForReview.ToString() && u.ActionNeeded == ActionNeeded.SupervisorPending.ToString()).FirstOrDefault();
        }

        
    }
}
