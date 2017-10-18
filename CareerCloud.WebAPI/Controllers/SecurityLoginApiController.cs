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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginApiController : ApiController
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginApiController()
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(false);
            _logic = new SecurityLoginLogic(repository);
        }

        [HttpGet]
        [Route("login/{securityLoginId}")]
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
        [Route("login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetSecurityLogin()
        {
            List<SecurityLoginPoco> securityLoginData = _logic.GetAll();
            return Ok(securityLoginData);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
