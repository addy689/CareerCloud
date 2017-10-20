﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.UI.MVC.Models.CreateJob
{
    public class CompanyCreateJobVM
    {
        [Display(Name = "Job Title")]
        public string JobName { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Display(Name = "Mark As Inactive?")]
        public bool IsInternal { get; set; }

        [Display(Name = "Mark As Internal Only?")]
        public bool IsCompanyHidden { get; set; }

        [Display(Name = "Required Skills")]
        public IEnumerable<JobSkillVM> JobSkills { get; set; }

        [Display(Name = "Required Education")]
        public IEnumerable<JobEducationVM> JobEducation { get; set; }
    }
}