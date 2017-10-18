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
    public class SecurityRoleApiController : ApiController
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleApiController()
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(false);
            _logic = new SecurityRoleLogic(repository);
        }

        [HttpGet]
        [Route("role/{securityRoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco securityRole = _logic.Get(securityRoleId);
            if (securityRole == null)
            {
                return NotFound();
            }

            return Ok(securityRole);
        }

        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetSecurityRole()
        {
            List<SecurityRolePoco> securityRoleData = _logic.GetAll();
            return Ok(securityRoleData);
        }

        [HttpPost]
        [Route("role")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("role")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
