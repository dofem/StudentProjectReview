using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Service.Implementation
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ApplicationDbContext _context;

        public SupervisorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supervisor> GetSupervisorById(int id)
        {
            var supervisor = _context.Supervisors.Where(u => u.Id == id).FirstOrDefault();
            if (supervisor == null)
            {
                throw new ApplicationException("supervisor not found");
            }
            return supervisor;
        }
    }
}
