using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models
{
    public class ApplicantJobApplicationVM
    {
        public Guid JobId { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}