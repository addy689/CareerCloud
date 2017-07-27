using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
    {
        public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
        { }

        public override void Add(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (ApplicantWorkHistoryPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyName) || poco.CompanyName.Length <= 2)
                    validationErrors.Add(new ValidationException(105, $"CompanyName for ApplicantWorkHistory {poco.CompanyName} must be greater than 2 characters"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}