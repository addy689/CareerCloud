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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(false);
            _logic = new SecurityLoginsRoleLogic(repository);
        }

        [HttpGet]
        [Route("education/{securityLoginsRoleId}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco securityLoginsRole = _logic.Get(securityLoginsRoleId);
            if (securityLoginsRole == null)
            {
                return NotFound();
            }

            return Ok(securityLoginsRole);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> securityLoginsRoleData = _logic.GetAll();
            return Ok(securityLoginsRoleData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
