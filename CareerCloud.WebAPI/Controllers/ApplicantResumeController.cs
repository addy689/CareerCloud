using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/_applicant/v1")]
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(false);
            _logic = new ApplicantResumeLogic(repository);
        }

        [HttpGet]
        [Route("education/{applicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid applicantResumeId)
        {
            ApplicantResumePoco applicantResume = _logic.Get(applicantResumeId);
            if (applicantResume == null)
            {
                return NotFound();
            }

            return Ok(applicantResume);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetApplicantResume()
        {
            List<ApplicantResumePoco> applicantResumeData = _logic.GetAll();
            return Ok(applicantResumeData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
