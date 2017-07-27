using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
        { }

        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (ApplicantResumePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Resume))
                    validationErrors.Add(new ValidationException(113, $"Resume for ApplicantResume {poco.Resume} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}