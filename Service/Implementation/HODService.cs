using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Service.Implementation
{
    public class HODService : IHODService
    {
        private readonly ApplicationDbContext _context;

        public HODService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HOD> GetHODById(int id)
        {
           var hod = _context.HODs.Where(u=>u.Id == id).FirstOrDefault();
            if (hod==null)
            {
                throw new ApplicationException("hod not found");
            }
            return hod;
        }
    }
}
