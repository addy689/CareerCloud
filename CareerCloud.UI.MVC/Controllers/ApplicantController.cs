using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.UI.MVC.Controllers
{
    public class ApplicantController : BaseController
    {
        // GET: ApplicantProfile
        public ActionResult Index()
        {
            //Request data from REST API
            string requestUri = GetApiUriString("applicant/v1/profile");
            var response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
            {
                return View(response.Content.ReadAsAsync<IList<ApplicantProfilePoco>>().Result);
            }
            
            return ErrorView(response);
        }

        // GET: ApplicantProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfile.Find(id);
            //if (applicantProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(applicantProfilePoco);
            return View("Error");
        }

        // GET: ApplicantProfile/Create
        public ActionResult Create()
        {
            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login");
            //ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name");
            //return View();
            return View("Error");

        }

        // POST: ApplicantProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    applicantProfilePoco.Id = Guid.NewGuid();
            //    db.ApplicantProfile.Add(applicantProfilePoco);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            //ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            //return View(applicantProfilePoco);
            return View("Error");

        }

        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfile.Find(id);
            //if (applicantProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            //ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            //return View(applicantProfilePoco);
            return View("Error");

        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(applicantProfilePoco).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            //ViewBag.Country = new SelectList(db.SystemCountryCode, "Code", "Name", applicantProfilePoco.Country);
            //return View(applicantProfilePoco);
            return View("Error");

        }

        // GET: ApplicantProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfile.Find(id);
            //if (applicantProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(applicantProfilePoco);
            return View("Error");

        }

        // POST: ApplicantProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfile.Find(id);
            //db.ApplicantProfile.Remove(applicantProfilePoco);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View("Error");

        }

    }
}
