using Microsoft.Win32;
using ProjectApprovalWorkflow.Data;
using ProjectApprovalWorkflow.Dto;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;
using System.Security.Cryptography;
using System.Text;

namespace ProjectApprovalWorkflow.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentService _studentService;
        private readonly ISupervisorService _supervisorService;
        private readonly IHODService _hODService;

        public UserService(ApplicationDbContext context,IStudentService studentService,ISupervisorService supervisorService,IHODService hODService)
        {
            _context = context;
            _studentService = studentService;
            _supervisorService = supervisorService;
            _hODService = hODService;
        }

        public Task<bool> IsValidUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(User user)
        {
            
            var checkUser = _context.Users.Where(u =>u.Id ==user.Id ).FirstOrDefault();
            if (checkUser != null)
            {
                throw new ApplicationException("User Already Exist");
            };
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new ApplicationException("User Already Exist");
            }
           
            user= AssignRole(user);
            user.Password = hashPassword(user.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
                      
        }


        public string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }

        private User AssignRole(User user)
        {
            if (user.Role == "student")
            {
                user.Role = "student";
                var student = new Student()
                {
                    UserId= user.Id,
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    Email= user.Email,
                    PhoneNumber= user.PhoneNumber,
                    ClassId = 1,
                };
                _context.Students.Add(student);
            }
            else if (user.Role == "supervisor")
            {
                user.Role = "supervisor";
                var supervisor = new Supervisor()
                {
                    UserId= user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };
                _context.Supervisors.Add(supervisor);
            }
            else if (user.Role == "hod")
            {
                user.Role = "hod";
                var hod = new HOD()
                {
                    UserId= user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };
                _context.HODs.Add(hod);
            }
            
            return user;
        }



       /** private string AssignRole(string Role)
        {
            if (Role == "Student")
            {
                Role = "Student";
               
            }
            else if (Role == "Supervisor")
            {
                Role = "supervisor";
               
            }
            else if (Role == "hod")
            {
                Role = "hod";
               
            }
           return Role;
        }**/

        public async Task<User> GetUserById(int Id)
        {
            var user = _context.Users.Where(_ => _.Id == Id).FirstOrDefault();
            if (user == null)
            {
                throw new ApplicationException("user doesnt exist");
            }
            return user;
        }

        public async Task<User> Login(LoginDto user)
        {
            string HashPassword = hashPassword(user.Password);
            var logged = _context.Users.Where(u=>u.Email== user.Email && u.Password == HashPassword).FirstOrDefault();
            if (logged == null)
            {
                throw new ApplicationException("Username or Password Incorrect");
            };
            return logged;
        }

        public Task<User> GetUserByEmail(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
