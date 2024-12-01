using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileUrl { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}