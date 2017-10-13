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
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(false);
            _logic = new SystemCountryCodeLogic(repository);
        }

        [HttpGet]
        [Route("education/{systemCountryCodeId}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string systemCountryCodeId)
        {
            SystemCountryCodePoco systemCountryCode = _logic.Get(systemCountryCodeId);
            if (systemCountryCode == null)
            {
                return NotFound();
            }

            return Ok(systemCountryCode);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetSystemCountryCode()
        {
            List<SystemCountryCodePoco> systemCountryCodeData = _logic.GetAll();
            return Ok(systemCountryCodeData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
