using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApprovalWorkflow.Service.Interface;

namespace ProjectApprovalWorkflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private IProjectService _projectService;
        private IMapper _mapper;

        public SupervisorController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ProjectsNeedingSupervisorReview")]
        public IActionResult ProjectsNeedingSupervisorApproval()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var projects = _projectService.GetAllProjectForSupervisorApproval();
            return Ok(projects);


        }
    }
}