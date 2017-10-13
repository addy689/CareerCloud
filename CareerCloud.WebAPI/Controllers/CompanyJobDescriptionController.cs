﻿using System;
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
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            _logic = new CompanyJobDescriptionLogic(repository);
        }

        [HttpGet]
        [Route("education/{companyJobDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobsDescription(Guid companyJobDescriptionId)
        {
            CompanyJobDescriptionPoco companyJobDescription = _logic.Get(companyJobDescriptionId);
            if (companyJobDescription == null)
            {
                return NotFound();
            }

            return Ok(companyJobDescription);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> companyJobDescriptionData = _logic.GetAll();
            return Ok(companyJobDescriptionData);
        }

        [HttpPost]
        [Route("education")]
        public IHttpActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public IHttpActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public IHttpActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
