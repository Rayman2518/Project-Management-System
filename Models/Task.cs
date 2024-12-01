using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskDetails { get; set; }
        public string TaskPriority { get; set; }
        public string TaskStatus { get; set; }
        public int ProjectId { get; set; }
        public int TeamMemberId { get; set; }

        public Project Project { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}