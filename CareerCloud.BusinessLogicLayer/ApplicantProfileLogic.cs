using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        { }

        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (ApplicantProfilePoco poco in pocos)
            {
                if (poco.CurrentSalary < 0)
                    validationErrors.Add(new ValidationException(111, $"CurrentSalary for ApplicantProfile {poco.CurrentSalary} cannot be negative"));

                if (poco.CurrentRate < 0)
                    validationErrors.Add(new ValidationException(112, $"CurrentRate for ApplicantProfile {poco.CurrentRate} cannot be negative"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}