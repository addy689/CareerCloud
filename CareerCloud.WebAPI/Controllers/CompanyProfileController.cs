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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(false);
            _logic = new CompanyProfileLogic(repository);
        }

        [HttpGet]
        [Route("education/{companyProfileId}")]
        [ResponseType(typeof(CompanyProfilePoco))]
        public IHttpActionResult GetCompanyProfile(Guid companyProfileId)
        {
            CompanyProfilePoco companyProfile = _logic.Get(companyProfileId);
            if (companyProfile == null)
            {
                return NotFound();
            }

            return Ok(companyProfile);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]
        public IHttpActionResult GetCompanyProfile()
        {
            List<CompanyProfilePoco> companyProfileData = _logic.GetAll();
            return Ok(companyProfileData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
