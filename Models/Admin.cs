using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public bool PrimaryAdmin { get; set; }
        public string RoleDescription { get; set; }
        public int ProfileId { get; set; }

        public Profile Profile { get; set; } // Navigation property
    }
}