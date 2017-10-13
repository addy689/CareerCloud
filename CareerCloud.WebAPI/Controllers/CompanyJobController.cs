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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;

        public CompanyJobController()
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(false);
            _logic = new CompanyJobLogic(repository);
        }

        [HttpGet]
        [Route("education/{companyJobId}")]
        [ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid companyJobId)
        {
            CompanyJobPoco companyJob = _logic.Get(companyJobId);
            if (companyJob == null)
            {
                return NotFound();
            }

            return Ok(companyJob);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetCompanyJob()
        {
            List<CompanyJobPoco> companyJobData = _logic.GetAll();
            return Ok(companyJobData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
