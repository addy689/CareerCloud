using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        { }

        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (CompanyJobDescriptionPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.JobName))
                    validationErrors.Add(new ValidationException(300, $"JobName for CompanyJobDescription {poco.JobName} cannot be empty"));

                if (string.IsNullOrEmpty(poco.JobDescriptions))
                    validationErrors.Add(new ValidationException(301, $"JobDescriptions for CompanyJobDescription {poco.JobDescriptions} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}