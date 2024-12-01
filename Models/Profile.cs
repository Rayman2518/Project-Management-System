using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ProfilePicPath { get; set; }
        public string UserType { get; set; }
        public int UserTypeId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}