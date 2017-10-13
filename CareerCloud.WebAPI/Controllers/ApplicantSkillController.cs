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
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(false);
            _logic = new ApplicantSkillLogic(repository);
        }

        [HttpGet]
        [Route("education/{applicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            ApplicantSkillPoco applicantSkill = _logic.Get(applicantSkillId);
            if (applicantSkill == null)
            {
                return NotFound();
            }

            return Ok(applicantSkill);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetApplicantSkill()
        {
            List<ApplicantSkillPoco> applicantSkillData = _logic.GetAll();
            return Ok(applicantSkillData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
