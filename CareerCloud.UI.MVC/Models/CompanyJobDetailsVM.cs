using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models
{
    public class CompanyJobDetailsVM
    {
        [Display(Name = "Job Title")]
        public string JobName { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Display(Name = "Date Posted")]
        public DateTime DatePosted { get; set; }

        [Display(Name = "Is Inactive")]
        public bool IsInactive { get; set; }

        [Display(Name = "Is Internal")]
        public bool IsCompanyHidden { get; set; }

        [Display(Name = "Required Skills")]
        public IEnumerable<CompanyJobSkillVM> JobSkills { get; set; }

        [Display(Name = "Required Education")]
        public IEnumerable<CompanyJobEducationVM> JobEducation { get; set; }

        public Guid Company { get; set; }
    }
}