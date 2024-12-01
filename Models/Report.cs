using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public float ProjectProgressPercentage { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int TimeSpent { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}