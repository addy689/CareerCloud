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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(false);
            _logic = new CompanyLocationLogic(repository);
        }

        [HttpGet]
        [Route("education/{companyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco companyLocation = _logic.Get(companyLocationId);
            if (companyLocation == null)
            {
                return NotFound();
            }

            return Ok(companyLocation);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetCompanyLocation()
        {
            List<CompanyLocationPoco> companyLocationData = _logic.GetAll();
            return Ok(companyLocationData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
