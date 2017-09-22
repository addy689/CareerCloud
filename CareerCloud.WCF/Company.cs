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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Company" in both code and config file together.
    public class Company : ICompany
    {
        #region CompanyDescription
        public void AddCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>(createProxy: false);
            CompanyDescriptionLogic bl = new CompanyDescriptionLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>(createProxy: false);
            CompanyDescriptionLogic bl = new CompanyDescriptionLogic(repository);

            return bl.GetAll();
        }

        public CompanyDescriptionPoco GetSingleCompanyDescription(string id)
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>(createProxy: false);
            CompanyDescriptionLogic bl = new CompanyDescriptionLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>(createProxy: false);
            CompanyDescriptionLogic bl = new CompanyDescriptionLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>(createProxy: false);
            CompanyDescriptionLogic bl = new CompanyDescriptionLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyJobDescription
        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(createProxy: false);
            CompanyJobDescriptionLogic bl = new CompanyJobDescriptionLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(createProxy: false);
            CompanyJobDescriptionLogic bl = new CompanyJobDescriptionLogic(repository);

            return bl.GetAll();
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string id)
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(createProxy: false);
            CompanyJobDescriptionLogic bl = new CompanyJobDescriptionLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(createProxy: false);
            CompanyJobDescriptionLogic bl = new CompanyJobDescriptionLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobDescriptionPoco>(createProxy: false);
            CompanyJobDescriptionLogic bl = new CompanyJobDescriptionLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyJobEducation
        public void AddCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>(createProxy: false);
            CompanyJobEducationLogic bl = new CompanyJobEducationLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>(createProxy: false);
            CompanyJobEducationLogic bl = new CompanyJobEducationLogic(repository);

            return bl.GetAll();
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string id)
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>(createProxy: false);
            CompanyJobEducationLogic bl = new CompanyJobEducationLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>(createProxy: false);
            CompanyJobEducationLogic bl = new CompanyJobEducationLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>(createProxy: false);
            CompanyJobEducationLogic bl = new CompanyJobEducationLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyJob
        public void AddCompanyJob(CompanyJobPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(createProxy: false);
            CompanyJobLogic bl = new CompanyJobLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(createProxy: false);
            CompanyJobLogic bl = new CompanyJobLogic(repository);

            return bl.GetAll();
        }

        public CompanyJobPoco GetSingleCompanyJob(string id)
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(createProxy: false);
            CompanyJobLogic bl = new CompanyJobLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJob(CompanyJobPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(createProxy: false);
            CompanyJobLogic bl = new CompanyJobLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyJob(CompanyJobPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobPoco>(createProxy: false);
            CompanyJobLogic bl = new CompanyJobLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyJobSkill
        public void AddCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(createProxy: false);
            CompanyJobSkillLogic bl = new CompanyJobSkillLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(createProxy: false);
            CompanyJobSkillLogic bl = new CompanyJobSkillLogic(repository);

            return bl.GetAll();
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string id)
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(createProxy: false);
            CompanyJobSkillLogic bl = new CompanyJobSkillLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(createProxy: false);
            CompanyJobSkillLogic bl = new CompanyJobSkillLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyJobSkillPoco>(createProxy: false);
            CompanyJobSkillLogic bl = new CompanyJobSkillLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyLocation
        public void AddCompanyLocation(CompanyLocationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(createProxy: false);
            CompanyLocationLogic bl = new CompanyLocationLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(createProxy: false);
            CompanyLocationLogic bl = new CompanyLocationLogic(repository);

            return bl.GetAll();
        }

        public CompanyLocationPoco GetSingleCompanyLocation(string id)
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(createProxy: false);
            CompanyLocationLogic bl = new CompanyLocationLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(createProxy: false);
            CompanyLocationLogic bl = new CompanyLocationLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyLocationPoco>(createProxy: false);
            CompanyLocationLogic bl = new CompanyLocationLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region CompanyProfile
        public void AddCompanyProfile(CompanyProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(createProxy: false);
            CompanyProfileLogic bl = new CompanyProfileLogic(repository);

            bl.Add(pocos);
        }

        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(createProxy: false);
            CompanyProfileLogic bl = new CompanyProfileLogic(repository);

            return bl.GetAll();
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string id)
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(createProxy: false);
            CompanyProfileLogic bl = new CompanyProfileLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(createProxy: false);
            CompanyProfileLogic bl = new CompanyProfileLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateCompanyProfile(CompanyProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<CompanyProfilePoco>(createProxy: false);
            CompanyProfileLogic bl = new CompanyProfileLogic(repository);

            bl.Update(pocos);
        }
        #endregion

    }
}
