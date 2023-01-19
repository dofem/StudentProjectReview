using System.Security.Claims;

namespace ProjectApprovalWorkflow.Model
{
    public class Student
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? ClassId { get; set; }
        
    }

}
