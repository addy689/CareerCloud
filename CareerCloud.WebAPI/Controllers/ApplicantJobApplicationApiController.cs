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
    public class ApplicantJobApplicationApiController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationApiController()
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
            _logic = new ApplicantJobApplicationLogic(repository);
        }

        //[HttpGet]
        //[Route("jobapplication/{applicantJobApplicationId}")]
        //[ResponseType(typeof(ApplicantJobApplicationPoco))]
        //public IHttpActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        //{
        //    ApplicantJobApplicationPoco applicantJobApplication = _logic.Get(applicantJobApplicationId);
        //    if (applicantJobApplication == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(applicantJobApplication);
        //}

        [HttpGet]
        [Route("jobapplication/{applicantId}")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult GetApplicantJobApplication(Guid? applicantId)
        {
            if(applicantId == null)
            {
                return BadRequest();
            }

            List<ApplicantJobApplicationPoco> applicantJobApplicationData = _logic.GetList(a => a.Applicant == applicantId, 
                                                                                            a => a.ApplicantProfiles, 
                                                                                            a => a.CompanyJobs.CompanyProfiles.CompanyDescriptions,
                                                                                            a => a.CompanyJobs.CompanyJobDescriptions);
              
            if(applicantJobApplicationData == null)
            {
                return NotFound();
            }

            return Ok(applicantJobApplicationData);
        }

        [HttpPost]
        [Route("jobapplication")]
        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication")]
        public IHttpActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication")]
        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
