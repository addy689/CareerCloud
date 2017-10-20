using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models
{
    public class SearchJobsVM
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime DatePosted { get; set; }
        public Guid JobId { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid CompanyId { get; set; }
    }
}