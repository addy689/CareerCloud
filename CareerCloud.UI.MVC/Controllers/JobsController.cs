using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using CareerCloud.UI.MVC.Models;

namespace CareerCloud.UI.MVC.Controllers
{
    public class JobsController : BaseController
    {
        // GET: ApplyJobs
        public ActionResult Search(Guid? applicantId)
        {
            string requestUri = GetApiUriString("company/v1/job");
            var response = Client.GetAsync(requestUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var allJobs = response.Content.ReadAsAsync<IList<CompanyJobPoco>>().Result;

                List<SearchJobsVM> viewModel = new List<SearchJobsVM>();
                foreach (CompanyJobPoco j in allJobs.Where(x => !x.IsInactive && !x.IsCompanyHidden))
                {
                    viewModel.Add(new SearchJobsVM
                    {
                        JobTitle = j.CompanyJobDescriptions.FirstOrDefault().JobName,
                        CompanyName = j.CompanyProfiles.CompanyDescriptions
                                                .Where(cd => cd.LanguageId.Trim() == "EN")
                                                .FirstOrDefault()
                                                .CompanyName,

                        DatePosted = j.ProfileCreated,
                        JobId = j.Id,
                        ApplicantId = applicantId.Value,
                        CompanyId = j.Company
                    });
                }

                return View(viewModel);
            }

            return ErrorView(response);
        }

        public ActionResult ShowJobDetails(Guid? companyId, Guid? jobId, Guid? applicantId)
        {
            if (companyId == null || jobId == null || applicantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string requestUri = GetApiUriString($"company/v1/job/{jobId}");
            var response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                CompanyJobPoco job = response.Content.ReadAsAsync<CompanyJobPoco>().Result;

                JobDetailsVM viewModel = new JobDetailsVM
                {
                    ApplicantId = applicantId.Value,
                    JobId = jobId.Value,
                    DatePosted = DateTime.Now,
                    Company = job.CompanyProfiles
                                 .CompanyDescriptions
                                 .Where(cd => cd.LanguageId.Trim() == "EN")
                                 .FirstOrDefault()
                                 .CompanyName,

                    Title = job.CompanyJobDescriptions.FirstOrDefault().JobName,
                    Description = job.CompanyJobDescriptions.FirstOrDefault().JobDescriptions,
                    Skills = job.CompanyJobSkills.Select(s => s.Skill),
                    Education = job.CompanyJobEducation.Select(e => e.Major)
                };

                return View(viewModel);
            }

            return ErrorView(response);
        }
        
    }
}