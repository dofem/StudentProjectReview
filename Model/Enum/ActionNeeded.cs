using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ProjectApprovalWorkflow.Model.Enum
{
    public enum ActionNeeded
    {
        SupervisorPending,
        HODPending,
        ReviseProject,
        
    }
}
