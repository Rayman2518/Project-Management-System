using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceUrl { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}