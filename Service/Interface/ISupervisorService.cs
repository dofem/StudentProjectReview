using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Service.Interface
{
    public interface ISupervisorService
    {
        Task<Supervisor> GetSupervisorById(int id);
    }
}
