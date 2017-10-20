using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Linq;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.UI.MVC.Models;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace CareerCloud.UI.MVC.Controllers
{
    public class ApplicantJobApplicationController : BaseController
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantJobApplication
        public ActionResult Index(Guid? applicantId)
        {
            if (applicantId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string requestUri = GetApiUriString($"applicant/v1/jobapplication/{applicantId}");
            var response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                List<ApplicantJobApplicationVM> viewModel = new List<ApplicantJobApplicationVM>();
                
                IEnumerable<ApplicantJobApplicationPoco> jobApplications = response.Content.ReadAsAsync<IList<ApplicantJobApplicationPoco>>().Result;
                foreach (var jobApplication in jobApplications)
                {
                    viewModel.Add(new ApplicantJobApplicationVM
                    {
                        JobId = jobApplication.Job,
                        JobTitle = jobApplication.CompanyJobs.CompanyJobDescriptions.FirstOrDefault().JobName,
                        Company = jobApplication.CompanyJobs.CompanyProfiles.CompanyDescriptions
                                                .Where(cd => cd.LanguageId.Trim() == "EN")
                                                .FirstOrDefault()
                                                .CompanyName,
                        ApplicationDate = jobApplication.ApplicationDate
                    });
                }

                response = Client.GetAsync(GetApiUriString($"applicant/v1/profile/{applicantId}")).Result;
                ViewBag.ApplicantName = response.Content.ReadAsAsync<ApplicantProfilePoco>().Result.SecurityLogins.FullName;
                ViewBag.ApplicantId = applicantId;

                return View(viewModel);
            }

            return ErrorView(response);
        }

        // GET: ApplicantJobApplication/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency");
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id");
            return View();
        }

        // POST: ApplicantJobApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Applicant,Job")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                applicantJobApplicationPoco.Id = Guid.NewGuid();
                applicantJobApplicationPoco.ApplicationDate = DateTime.Now;

                //Prepare data to POST to WebAPI
                string serialized = JsonConvert.SerializeObject(new ApplicantJobApplicationPoco[] { applicantJobApplicationPoco });
                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(serialized, Encoding.UTF8, "application/json")
                };
                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                //Now POST data
                string requestUri = GetApiUriString("applicant/v1/jobapplication");
                var response = Client.PostAsync(requestUri, inputMessage.Content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { applicantId = applicantJobApplicationPoco.Applicant });
                }

                return ErrorView(response);
            }
            //ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantJobApplicationPoco.Applicant);
            //ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            //return View(applicantJobApplicationPoco);
            return View("Error");
        }

        // GET: ApplicantJobApplication/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantJobApplicationPoco.Applicant);
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Job,ApplicationDate,TimeStamp")] ApplicantJobApplicationPoco applicantJobApplicationPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantJobApplicationPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantJobApplicationPoco.Applicant);
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", applicantJobApplicationPoco.Job);
            return View(applicantJobApplicationPoco);
        }

        // GET: ApplicantJobApplication/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id);
            if (applicantJobApplicationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantJobApplicationPoco);
        }

        // POST: ApplicantJobApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = db.ApplicantJobApplication.Find(id);
            db.ApplicantJobApplication.Remove(applicantJobApplicationPoco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
