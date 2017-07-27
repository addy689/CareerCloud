using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        { }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (ApplicantSkillPoco poco in pocos)
            {
                if (poco.StartMonth > 12)
                    validationErrors.Add(new ValidationException(101, $"StartMonth for ApplicantSkill {poco.StartMonth} cannot be greater than 12"));

                if (poco.EndMonth > 12)
                    validationErrors.Add(new ValidationException(102, $"EndMonth for ApplicantSkill {poco.EndMonth} cannot be greater than 12"));

                if (poco.StartYear < 1900)
                    validationErrors.Add(new ValidationException(103, $"StartYear for ApplicantSkill {poco.StartYear} cannot be less than 1900"));

                if (poco.EndYear < poco.StartYear)
                    validationErrors.Add(new ValidationException(104, $"EndYear for ApplicantSkill {poco.EndYear} cannot be less than StartYear {poco.StartYear}"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}