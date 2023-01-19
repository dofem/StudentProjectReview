using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Service.Interface
{
    public interface IHODService
    {
        Task<HOD> GetHODById(int id);
    }
}
