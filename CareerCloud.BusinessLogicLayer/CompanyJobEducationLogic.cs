using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        { }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (CompanyJobEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length < 2)
                    validationErrors.Add(new ValidationException(200, $"Major for CompanyJobEducation {poco.Major} must be at least 2 characters"));

                if (poco.Importance < 0)
                    validationErrors.Add(new ValidationException(201, $"Importance for CompanyJobEducation {poco.Importance} cannot be less than 0"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}