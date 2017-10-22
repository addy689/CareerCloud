using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CareerCloud.Pocos;
using CareerCloud.UI.MVC.Models;

namespace CareerCloud.UI.MVC.Controllers
{
    public class JobSearchController : BaseController
    {
        // GET: ApplyJobs
        public ActionResult Search(Guid? applicantId, string search, string sortProperty, ListSortDirection? sortDirection)
        {
            if (applicantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ApplicantId = applicantId;

            /* Generate sort order info for putting into hyperlinks
             */
            var tempVM = new ApplicantJobSearchVM();

            //set the defaults first
            sortProperty = sortProperty ?? GetPropertyName(() => tempVM.DatePosted);
            sortDirection = sortDirection ?? ListSortDirection.Descending;

            //- Generate hyperlink info for View
            //- Initialize and assign sort data
            Func<ApplicantJobSearchVM, object> sortPropertySelector = null;
            if (sortProperty == GetPropertyName(() => tempVM.DatePosted))
            {
                ViewBag.DatePostedSortDirection = sortDirection == ListSortDirection.Ascending ?
                                                ListSortDirection.Descending : ListSortDirection.Ascending;

                ViewBag.JobTitleSortDirection = ListSortDirection.Ascending;
                ViewBag.CompanyNameSortDirection = ListSortDirection.Ascending;

                sortPropertySelector = vm => vm.DatePosted;
            }

            else if (sortProperty == GetPropertyName(() => tempVM.JobTitle))
            {
                ViewBag.DatePostedSortDirection = ListSortDirection.Descending;

                ViewBag.JobTitleSortDirection = sortDirection == ListSortDirection.Ascending ?
                                                    ListSortDirection.Descending : ListSortDirection.Ascending;

                ViewBag.CompanyNameSortDirection = ListSortDirection.Ascending;

                sortPropertySelector = vm => vm.JobTitle;
            }

            else if (sortProperty == GetPropertyName(() => tempVM.CompanyName))
            {
                ViewBag.DatePostedSortDirection = ListSortDirection.Descending;

                ViewBag.JobTitleSortDirection = ListSortDirection.Ascending;

                ViewBag.CompanyNameSortDirection = sortDirection == ListSortDirection.Ascending ?
                                                    ListSortDirection.Descending : ListSortDirection.Ascending;

                sortPropertySelector = vm => vm.CompanyName;
            }

            //Now perform Search
            string requestUri = GetApiUriString("company/v1/job");
            var response = Client.GetAsync(requestUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var allJobs = response.Content.ReadAsAsync<IList<CompanyJobPoco>>().Result;

                List<ApplicantJobSearchVM> viewModel = new List<ApplicantJobSearchVM>();
                foreach (CompanyJobPoco j in allJobs.Where(x => !x.IsInactive && !x.IsCompanyHidden))
                {
                    viewModel.Add(new ApplicantJobSearchVM
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

                var sortedViewModel = sortDirection == ListSortDirection.Ascending ?
                                            viewModel.OrderBy(sortPropertySelector) :
                                            viewModel.OrderByDescending(sortPropertySelector);
                                            
                return View(sortedViewModel);
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

                ApplicantJobDetailsVM viewModel = new ApplicantJobDetailsVM
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