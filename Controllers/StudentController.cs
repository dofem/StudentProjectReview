using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApprovalWorkflow.Dto;
using ProjectApprovalWorkflow.Model;
using ProjectApprovalWorkflow.Service.Interface;
using System.Reflection;

namespace ProjectApprovalWorkflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IProjectService _projectService;
        private IMapper _mapper;

        public StudentController(IProjectService projectService,IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("SubmitAProject")]
        public IActionResult SubmitAProject([FromBody]StudentAddProjectDto projectdto) 
        { 
            if (projectdto == null)
            {
                return BadRequest();
            }

            Project project = new()
            {
               Title= projectdto.Title,
               Description= projectdto.Description,
               Attachment = projectdto.Attachment,
            };
            var p = _projectService.AddProject(project);
            var theproject = _mapper.Map<StudentAddProjectDto>(p);
            return Ok("Project is Submitted Successfully");
        }
    }
}
