using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectApprovalWorkflow.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectApprovalWorkflow.Model
{
    public class Project
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        
        public int? SupervisorId { get; set; }
        public int? HODId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }        
        public string CurrentStatus { get; set; }       
        public string ActionNeeded { get; set; }
        public string? IsReviewed { get; set; }
        public string? IsApprovalSatisfied { get; set; }
        public string? IsReviewedBySupervisor { get; set; }
        public string? IsReviewedByHOD { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
       
    }

}
