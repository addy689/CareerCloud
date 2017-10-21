using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.UI.MVC.Models;

namespace CareerCloud.UI.MVC.Controllers
{
    public class CompanyJobController : BaseController
    {
        // GET: CompanyJob
        public ActionResult Index(Guid? companyId)
        {
            if (companyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string requestUri = GetApiUriString($"company/v1/job?companyId={companyId}");
            var response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                List<CompanyJobsListVM> viewModel = new List<CompanyJobsListVM>();

                IEnumerable<CompanyJobPoco> companyJobs = response.Content.ReadAsAsync<IList<CompanyJobPoco>>().Result;
                foreach (CompanyJobPoco companyJob in companyJobs)
                {
                    viewModel.Add(new CompanyJobsListVM
                    {
                        Id = companyJob.Id,
                        JobTitle = companyJob.CompanyJobDescriptions.FirstOrDefault().JobName,
                        DatePosted = companyJob.ProfileCreated,
                        IsInactive = companyJob.IsInactive,
                        IsInternalPosition = companyJob.IsCompanyHidden
                    });
                }

                response = Client.GetAsync(GetApiUriString($"company/v1/profile/{companyId}")).Result;
                ViewBag.CompanyId = companyId;
                ViewBag.CompanyName = response.Content.ReadAsAsync<CompanyProfilePoco>().Result
                                            .CompanyDescriptions.Where(cd => cd.LanguageId.Trim() == "EN")
                                            .FirstOrDefault()
                                            .CompanyName;

                return View(viewModel);
            }

            return ErrorView(response);
        }

        // GET: CompanyJob/Details/5
        public ActionResult Details(Guid? jobId, Guid? companyId)
        {
            if (companyId == null || jobId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string requestUri = GetApiUriString($"company/v1/job/{jobId}");
            var response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                CompanyJobPoco job = response.Content.ReadAsAsync<CompanyJobPoco>().Result;

                CompanyJobDetailsVM viewModel = new CompanyJobDetailsVM
                {
                    DatePosted = DateTime.Now,
                    Company = companyId.Value,
                    JobName = job.CompanyJobDescriptions.FirstOrDefault().JobName,
                    JobDescription = job.CompanyJobDescriptions.FirstOrDefault().JobDescriptions,

                    JobSkills = job.CompanyJobSkills
                                .Select(s => new CompanyJobSkillVM
                                {
                                    SkillName = s.Skill,
                                    SelectedSkillLevel = s.SkillLevel,
                                    SelectedImportance = s.Importance.ToString()
                                }),

                    JobEducation = job.CompanyJobEducation
                                .Select(ed => new CompanyJobEducationVM
                                {
                                    Major = ed.Major,
                                    SelectedImportance = ed.Importance.ToString()
                                })
                };

                ViewBag.CompanyName = job.CompanyProfiles
                                 .CompanyDescriptions
                                 .Where(cd => cd.LanguageId.Trim() == "EN")
                                 .FirstOrDefault()
                                 .CompanyName;
                
                ViewBag.CompanyId = companyId;

                return View(viewModel);
            }

            return ErrorView(response);
        }    

        // GET: CompanyJob/Create
        public ActionResult Create(Guid? companyId)
        {
            if (companyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = Client.GetAsync(GetApiUriString($"company/v1/profile/{companyId}")).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.CompanyName = response.Content.ReadAsAsync<CompanyProfilePoco>().Result
                                            .CompanyDescriptions.Where(cd => cd.LanguageId.Trim() == "EN")
                                            .FirstOrDefault()
                                            .CompanyName;

                ViewBag.CompanyId = companyId;

                return View();
            }

            return ErrorView(response);
        }

        // POST: CompanyJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "JobName,JobDescription,IsInactive,IsCompanyHidden,JobSkills,JobEducation,Company")] CompanyJobDetailsVM companyJobDetailsVM)
        {
            if (!ModelState.IsValid)
                return View(companyJobDetailsVM);

            bool isCreateSuccess = true;

            //Create new Job info
            CompanyJobPoco jobPoco = new CompanyJobPoco
            {
                Id = Guid.NewGuid(),
                ProfileCreated = DateTime.Now,
                Company = companyJobDetailsVM.Company,
                IsInactive = companyJobDetailsVM.IsInactive,
                IsCompanyHidden = companyJobDetailsVM.IsCompanyHidden,
            };
            isCreateSuccess &= PostToServer(new CompanyJobPoco[] { jobPoco }, "company/v1/job").IsSuccessStatusCode;

            //Create Job Description info
            CompanyJobDescriptionPoco descPoco = new CompanyJobDescriptionPoco
            {
                Id = Guid.NewGuid(),
                Job = jobPoco.Id,
                JobName = companyJobDetailsVM.JobName,
                JobDescriptions = companyJobDetailsVM.JobDescription
            };
            isCreateSuccess &= PostToServer(new CompanyJobDescriptionPoco[] { descPoco }, "company/v1/jobdescription").IsSuccessStatusCode;

            //Create Job Skills info
            List<CompanyJobSkillPoco> skillPocos = new List<CompanyJobSkillPoco>();
            foreach(var s in companyJobDetailsVM.JobSkills)
            {
                skillPocos.Add(new CompanyJobSkillPoco
                {
                    Id = Guid.NewGuid(),
                    Job = jobPoco.Id,
                    Skill = s.SkillName,
                    SkillLevel = s.SelectedSkillLevel,
                    Importance = int.Parse(s.SelectedImportance)
                });
            }
            isCreateSuccess &= PostToServer(skillPocos.ToArray(), "company/v1/jobskill").IsSuccessStatusCode;

            //Create Job Education info
            List<CompanyJobEducationPoco> educationPocos = new List<CompanyJobEducationPoco>();
            foreach (var e in companyJobDetailsVM.JobEducation)
            {
                educationPocos.Add(new CompanyJobEducationPoco
                {
                    Id = Guid.NewGuid(),
                    Job = jobPoco.Id,
                    Major = e.Major,
                    Importance = short.Parse(e.SelectedImportance)
                });
            }
            isCreateSuccess &= PostToServer(educationPocos.ToArray(), "company/v1/jobeducation").IsSuccessStatusCode;

            
            //Finally, check if the complete Job Creation process was successful
            if (isCreateSuccess)
            {
                return RedirectToAction("Index", new { companyId = companyJobDetailsVM.Company });
            }

            return View("Error");
        }

        // GET: CompanyJob/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            //if (companyJobPoco == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            //return View(companyJobPoco);
            return View("Error");
        }

        // POST: CompanyJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden,TimeStamp")] CompanyJobPoco companyJobPoco)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(companyJobPoco).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            //return View(companyJobPoco);
            return View("Error");

        }

        // GET: CompanyJob/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            //if (companyJobPoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(companyJobPoco);
            return View("Error");

        }

        // POST: CompanyJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            //db.CompanyJob.Remove(companyJobPoco);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View("Error");

        }
        
    }
}
