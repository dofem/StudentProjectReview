using ProjectApprovalWorkflow.Dto;
using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Service.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        Task<bool> IsValidUser(int Id);

        Task<User> GetUserById(int Id);
        Task<User> GetUserByEmail(string Email);

        Task<User> Login(LoginDto user);
    }
}
