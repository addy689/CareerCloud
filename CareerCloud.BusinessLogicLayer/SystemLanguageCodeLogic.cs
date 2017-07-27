using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {
        protected IDataRepository<SystemLanguageCodePoco> _repository;

        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        { }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                    validationErrors.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCode {poco.LanguageID} cannot be empty"));

                if (string.IsNullOrEmpty(poco.Name))
                    validationErrors.Add(new ValidationException(1001, $"Name for SystemLanguageCode {poco.Name} cannot be empty"));

                if (string.IsNullOrEmpty(poco.NativeName))
                    validationErrors.Add(new ValidationException(1002, $"NativeName for SystemLanguageCode {poco.NativeName} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}