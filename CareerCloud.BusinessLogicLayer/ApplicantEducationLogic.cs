using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        { }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                    validationErrors.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} cannot be empty"));
                else if (poco.Major.Length < 3)
                    validationErrors.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} cannot be less than 3 characters"));

                if (poco.StartDate > DateTime.Today)
                    validationErrors.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.StartDate} cannot be greater than today"));

                if (poco.CompletionDate < poco.StartDate)
                    validationErrors.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {poco.CompletionDate} cannot be earlier than StartDate {poco.StartDate}"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}