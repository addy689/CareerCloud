using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class CompanyJobApiController : ApiController
    {
        private CompanyJobLogic _logic;

        public CompanyJobApiController()
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(false);
            _logic = new CompanyJobLogic(repository);
        }

        [HttpGet]
        [Route("job/{companyJobId}")]
        [ResponseType(typeof(CompanyJobPoco))]
        public IHttpActionResult GetCompanyJob(Guid companyJobId)
        {
            CompanyJobPoco companyJob = _logic.Get(companyJobId,
                                                    j => j.CompanyProfiles.CompanyDescriptions,
                                                    j=>j.CompanyJobDescriptions,
                                                    j=>j.CompanyJobSkills,
                                                    j=>j.CompanyJobEducation);
            if (companyJob == null)
            {
                return NotFound();
            }

            return Ok(companyJob);
        }

        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]
        public IHttpActionResult GetCompanyJobs(Guid? companyId = null)
        {
            List<CompanyJobPoco> companyJobData;

            //Call appropriate BL method based on request
            if (companyId != null)
                companyJobData = _logic.GetList(j => j.Company == companyId, j => j.CompanyJobDescriptions);
            else
                companyJobData = _logic.GetAll(j => j.CompanyJobDescriptions, j => j.CompanyProfiles.CompanyDescriptions);

            //return error response if requested data not found
            if (companyJobData == null)
                return NotFound();

            return Ok(companyJobData);
        }

        [HttpPost]
        [Route("job")]
        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("job")]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("job")]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
