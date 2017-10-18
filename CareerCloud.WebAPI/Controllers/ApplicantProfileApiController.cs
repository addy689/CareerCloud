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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantProfileApiController : ApiController
    {
        private ApplicantProfileLogic _logic;

        public ApplicantProfileApiController()
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(false);
            _logic = new ApplicantProfileLogic(repository);
        }

        [HttpGet]
        [Route("profile/{applicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public IHttpActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            ApplicantProfilePoco applicantProfile = _logic.Get(applicantProfileId, a => a.SecurityLogins, a => a.SystemCountryCodes);
            if (applicantProfile == null)
            {
                return NotFound();
            }

            return Ok(applicantProfile);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]
        public IHttpActionResult GetApplicantProfile()
        {
            List<ApplicantProfilePoco> applicantProfileData = _logic.GetAll(a => a.SecurityLogins, a => a.SystemCountryCodes);
            return Ok(applicantProfileData);
        }

        [HttpPost]
        [Route("profile")]
        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
