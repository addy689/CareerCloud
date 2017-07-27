using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        { }

        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (CompanyDescriptionPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyDescription) || poco.CompanyDescription.Length <= 2)
                    validationErrors.Add(new ValidationException(107, $"CompanyDescription for CompanyDescription {poco.CompanyDescription} must be greater than 2 characters"));
                
                if (string.IsNullOrEmpty(poco.CompanyName) || poco.CompanyName.Length <= 2)
                    validationErrors.Add(new ValidationException(106, $"CompanyName for CompanyDescription {poco.CompanyName} must be greater than 2 characters"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}