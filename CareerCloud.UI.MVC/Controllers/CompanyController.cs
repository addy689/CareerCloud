using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.UI.MVC.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: CompanyProfile
        public ActionResult Index()
        {
            string requestUri = GetApiUriString("company/v1/profile");
            var response = Client.GetAsync(requestUri).Result;

            if(response.IsSuccessStatusCode)
            {
                return View(response.Content.ReadAsAsync<IList<CompanyProfilePoco>>().Result);
            }
            
            return ErrorView(response);
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            //if (companyProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(companyProfilePoco);
            return View("Error");
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    companyProfilePoco.Id = Guid.NewGuid();
            //    db.CompanyProfile.Add(companyProfilePoco);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(companyProfilePoco);
            return View("Error");
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            //if (companyProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(companyProfilePoco);
            return View("Error");
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(companyProfilePoco).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(companyProfilePoco);
            return View("Error");
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            //if (companyProfilePoco == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(companyProfilePoco);
            return View("Error");
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            //db.CompanyProfile.Remove(companyProfilePoco);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View("Error");
        }
        
    }
}
