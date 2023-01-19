using AutoMapper;
using ProjectApprovalWorkflow.Dto;
using ProjectApprovalWorkflow.Model;

namespace ProjectApprovalWorkflow.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<Project,StudentAddProjectDto>().ReverseMap();
        }

    }
}
