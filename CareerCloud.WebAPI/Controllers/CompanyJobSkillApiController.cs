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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobSkillApiController : ApiController
    {
        private CompanyJobSkillLogic _logic;

        public CompanyJobSkillApiController()
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(false);
            _logic = new CompanyJobSkillLogic(repository);
        }

        [HttpGet]
        [Route("jobskill/{companyJobSkillId}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]
        public IHttpActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            CompanyJobSkillPoco companyJobSkill = _logic.Get(companyJobSkillId);
            if (companyJobSkill == null)
            {
                return NotFound();
            }

            return Ok(companyJobSkill);
        }

        [HttpGet]
        [Route("jobskill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]
        public IHttpActionResult GetCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> companyJobSkillData = _logic.GetAll();
            return Ok(companyJobSkillData);
        }

        [HttpPost]
        [Route("jobskill")]
        public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobskill")]
        public IHttpActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobskill")]
        public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
