using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectPriority { get; set; }
        public int ProjectBudget { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
        public int TeamId { get; set; }

        public Client Client { get; set; }
        public Manager Manager { get; set; }
        public Team Team { get; set; }
    }
}