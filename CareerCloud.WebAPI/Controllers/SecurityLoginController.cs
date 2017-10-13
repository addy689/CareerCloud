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
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(false);
            _logic = new SecurityLoginLogic(repository);
        }

        [HttpGet]
        [Route("education/{securityLoginId}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco securityLogin = _logic.Get(securityLoginId);
            if (securityLogin == null)
            {
                return NotFound();
            }

            return Ok(securityLogin);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetSecurityLogin()
        {
            List<SecurityLoginPoco> securityLoginData = _logic.GetAll();
            return Ok(securityLoginData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
