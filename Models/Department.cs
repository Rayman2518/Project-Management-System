using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string DepLocation { get; set; }
        public int DepAnnualBudget { get; set; }
    }
}