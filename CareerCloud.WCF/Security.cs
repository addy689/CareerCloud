using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in both code and config file together.
    public class Security : ISecurity
    {
        #region SecurityLogin
        public void AddSecurityLogin(SecurityLoginPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(createProxy: false);
            SecurityLoginLogic bl = new SecurityLoginLogic(repository);

            bl.Add(pocos);
        }

        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(createProxy: false);
            SecurityLoginLogic bl = new SecurityLoginLogic(repository);

            return bl.GetAll();
        }

        public SecurityLoginPoco GetSingleSecurityLogin(string id)
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(createProxy: false);
            SecurityLoginLogic bl = new SecurityLoginLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveSecurityLogin(SecurityLoginPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(createProxy: false);
            SecurityLoginLogic bl = new SecurityLoginLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSecurityLogin(SecurityLoginPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>(createProxy: false);
            SecurityLoginLogic bl = new SecurityLoginLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region SecurityLoginsLog
        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>(createProxy: false);
            SecurityLoginsLogLogic bl = new SecurityLoginsLogLogic(repository);

            bl.Add(pocos);
        }

        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>(createProxy: false);
            SecurityLoginsLogLogic bl = new SecurityLoginsLogLogic(repository);

            return bl.GetAll();
        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string id)
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>(createProxy: false);
            SecurityLoginsLogLogic bl = new SecurityLoginsLogLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>(createProxy: false);
            SecurityLoginsLogLogic bl = new SecurityLoginsLogLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>(createProxy: false);
            SecurityLoginsLogLogic bl = new SecurityLoginsLogLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region SecurityLoginsRole
        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(createProxy: false);
            SecurityLoginsRoleLogic bl = new SecurityLoginsRoleLogic(repository);

            bl.Add(pocos);
        }

        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(createProxy: false);
            SecurityLoginsRoleLogic bl = new SecurityLoginsRoleLogic(repository);

            return bl.GetAll();
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string id)
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(createProxy: false);
            SecurityLoginsRoleLogic bl = new SecurityLoginsRoleLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(createProxy: false);
            SecurityLoginsRoleLogic bl = new SecurityLoginsRoleLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityLoginsRolePoco>(createProxy: false);
            SecurityLoginsRoleLogic bl = new SecurityLoginsRoleLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region SecurityRole
        public void AddSecurityRole(SecurityRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(createProxy: false);
            SecurityRoleLogic bl = new SecurityRoleLogic(repository);

            bl.Add(pocos);
        }

        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(createProxy: false);
            SecurityRoleLogic bl = new SecurityRoleLogic(repository);

            return bl.GetAll();
        }

        public SecurityRolePoco GetSingleSecurityRole(string id)
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(createProxy: false);
            SecurityRoleLogic bl = new SecurityRoleLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveSecurityRole(SecurityRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(createProxy: false);
            SecurityRoleLogic bl = new SecurityRoleLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSecurityRole(SecurityRolePoco[] pocos)
        {
            var repository = new EFGenericRepository<SecurityRolePoco>(createProxy: false);
            SecurityRoleLogic bl = new SecurityRoleLogic(repository);

            bl.Update(pocos);
        }
        #endregion
        
    }
}
