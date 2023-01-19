using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApprovalWorkflow.Dto;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(User User)
        {
            if (User == null)
            {
                return BadRequest();
            }
            var CheckUser = _userService.GetUserById(User.Id);
            if (CheckUser == null)
            {
                return BadRequest("User Already Exist");
            }
 
            var register = await _userService.RegisterUser(User);
            var registered = _mapper.Map<User>(register);

            return Ok("User is registered Successfully");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody]LoginDto login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            var dbUser = _userService.Login(login);

            if (dbUser == null)
            {
                return BadRequest("Username or Password Incorect");
            }
            return Ok("Login is Successful");

        }


    }
}
