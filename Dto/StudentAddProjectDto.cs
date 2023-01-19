using ProjectApprovalWorkflow.Model.Enum;
using ProjectApprovalWorkflow.Model;
using System.ComponentModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ProjectApprovalWorkflow.Dto
{
    public class StudentAddProjectDto
    {
            
            public int StudentId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Attachment { get; set; }
            public DateTime SubmissionDate { get; set; } = DateTime.Now;
            
        
    }
}
