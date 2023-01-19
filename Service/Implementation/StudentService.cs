using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = _context.Students.Where(u => u.Id == id).FirstOrDefault();
            if (student == null)
            {
                throw new ApplicationException("student not found");
            }
            return student;
        }
    }
}
