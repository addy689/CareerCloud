using System;
using System.Collections.Generic;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
    {
        public SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : base(repository)
        { }

        public override void Add(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SecurityRolePoco[] pocos)
        {
            List<ValidationException> validationErrors = new List<ValidationException>();

            foreach (SecurityRolePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Role))
                    validationErrors.Add(new ValidationException(800, $"Role for SecurityRole {poco.Role} cannot be empty"));
            }

            if (validationErrors.Count > 0)
                throw new AggregateException(validationErrors);
        }
    }
}