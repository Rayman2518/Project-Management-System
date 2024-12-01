using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }
        public int Rank { get; set; }
        public int MonthlyPay { get; set; }
        public int WeekWorkHours { get; set; }
        public int ProfileId { get; set; }
        public int DepId { get; set; }
        public int ManagerId { get; set; }
        public int TeamId { get; set; }

        public Profile Profile { get; set; }
        public Department Department { get; set; }
        public Manager Manager { get; set; }
        public Team Team { get; set; }
    }
}