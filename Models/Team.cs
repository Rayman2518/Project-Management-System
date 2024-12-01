using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public int TeamSize { get; set; }
        public int ManagerId { get; set; }

        public Manager Manager { get; set; } // Navigation property
    }
}