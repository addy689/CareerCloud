using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;

        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        { }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                    validationErrors.Add(new ValidationException(900, $"Code for SystemCountryCode {poco.Code} cannot be empty"));
                
                if (string.IsNullOrEmpty(poco.Name))
                    validationErrors.Add(new ValidationException(901, $"Code for SystemCountryCode {poco.Name} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}