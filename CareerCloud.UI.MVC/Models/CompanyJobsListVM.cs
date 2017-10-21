using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models
{
    public class CompanyJobsListVM
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime DatePosted{ get; set; }
        public bool IsInactive { get; set; }
        public bool IsInternalPosition { get; set; }
    }
}