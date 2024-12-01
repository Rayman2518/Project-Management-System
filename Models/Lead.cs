using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Lead
    {
        public int LeadId { get; set; }
        public string LeadName { get; set; }
        public string LeadDescription { get; set; }
        public string Status { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string LeadPriority { get; set; }
        public string Source { get; set; }
        public DateTime DateCreated { get; set; }
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }
    }
}