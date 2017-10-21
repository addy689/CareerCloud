using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models
{
    public class ApplicantJobDetailsVM
    {
        public DateTime DatePosted { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Required Education")]
        public IEnumerable<string> Education { get; set; }

        [Display(Name = "Required Skills")]

        public IEnumerable<string> Skills { get; set; }

        [Display(Name = "Applicant")]
        public Guid ApplicantId { get; set; }
        
        [Display(Name = "Job")]
        public Guid JobId { get; set; }

    }
}