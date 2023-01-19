using Microsoft.EntityFrameworkCore;
using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Service.Interface
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<Project> UpdateProject(int id,Project project);
        Task<Project> DeleteProject(int id);
        Task<Project> AddProject(Project project);
        Task<List<Project>> GetAllProjectForSupervisorApproval();
        Task<Project> GetProjectForSupervisorApproval(int id);
    }
}
