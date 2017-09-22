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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "System" in both code and config file together.
    public class System : ISystem
    {
        #region SystemCountryCode
        public void AddSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(createProxy: false);
            SystemCountryCodeLogic bl = new SystemCountryCodeLogic(repository);

            bl.Add(pocos);
        }

        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(createProxy: false);
            SystemCountryCodeLogic bl = new SystemCountryCodeLogic(repository);

            return bl.GetAll();
        }

        public SystemCountryCodePoco GetSingleSystemCountryCode(string id)
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(createProxy: false);
            SystemCountryCodeLogic bl = new SystemCountryCodeLogic(repository);

            return bl.Get(id);
        }

        public void RemoveSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(createProxy: false);
            SystemCountryCodeLogic bl = new SystemCountryCodeLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemCountryCodePoco>(createProxy: false);
            SystemCountryCodeLogic bl = new SystemCountryCodeLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region SystemLanguageCode
        public void AddSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(createProxy: false);
            SystemLanguageCodeLogic bl = new SystemLanguageCodeLogic(repository);

            bl.Add(pocos);
        }

        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(createProxy: false);
            SystemLanguageCodeLogic bl = new SystemLanguageCodeLogic(repository);

            return bl.GetAll();
        }

        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string id)
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(createProxy: false);
            SystemLanguageCodeLogic bl = new SystemLanguageCodeLogic(repository);

            return bl.Get(id);
        }

        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(createProxy: false);
            SystemLanguageCodeLogic bl = new SystemLanguageCodeLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>(createProxy: false);
            SystemLanguageCodeLogic bl = new SystemLanguageCodeLogic(repository);

            bl.Update(pocos);
        }
        #endregion

    }
}
