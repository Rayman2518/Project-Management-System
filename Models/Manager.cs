using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Domain { get; set; }
        public int ExperienceYears { get; set; }
        public int YearlyPay { get; set; }
        public int DepId { get; set; }
        public int ProfileId { get; set; }

        public Department Department { get; set; } // Navigation property
        public Profile Profile { get; set; } // Navigation property
    }
}