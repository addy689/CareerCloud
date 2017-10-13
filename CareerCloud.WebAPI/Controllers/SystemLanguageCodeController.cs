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
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(false);
            _logic = new SystemLanguageCodeLogic(repository);
        }

        [HttpGet]
        [Route("education/{systemLanguageCodeId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string systemLanguageCodeId)
        {
            SystemLanguageCodePoco systemLanguageCode = _logic.Get(systemLanguageCodeId);
            if (systemLanguageCode == null)
            {
                return NotFound();
            }

            return Ok(systemLanguageCode);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> systemLanguageCodeData = _logic.GetAll();
            return Ok(systemLanguageCodeData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
