using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Service.Interface
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(int id);
    }
}
