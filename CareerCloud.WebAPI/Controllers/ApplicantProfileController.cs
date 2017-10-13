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
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(false);
            _logic = new ApplicantProfileLogic(repository);
        }

        [HttpGet]
        [Route("education/{applicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            ApplicantProfilePoco applicantProfile = _logic.Get(applicantProfileId);
            if (applicantProfile == null)
            {
                return NotFound();
            }

            return Ok(applicantProfile);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetApplicantProfile()
        {
            List<ApplicantProfilePoco> applicantProfileData = _logic.GetAll();
            return Ok(applicantProfileData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
