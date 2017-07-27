using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        { }

        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (CompanyLocationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CountryCode))
                    validationErrors.Add(new ValidationException(500, $"CountryCode for CompanyLocation {poco.CountryCode} cannot be empty"));

                if (string.IsNullOrEmpty(poco.Province))
                    validationErrors.Add(new ValidationException(501, $"Province for CompanyLocation {poco.Province} cannot be empty"));

                if (string.IsNullOrEmpty(poco.Street))
                    validationErrors.Add(new ValidationException(502, $"Street for CompanyLocation {poco.Street} cannot be empty"));

                if (string.IsNullOrEmpty(poco.City))
                    validationErrors.Add(new ValidationException(503, $"City for CompanyLocation {poco.City} cannot be empty"));

                if (string.IsNullOrEmpty(poco.PostalCode))
                    validationErrors.Add(new ValidationException(504, $"PostalCode for CompanyLocation {poco.PostalCode} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}