using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WCF
{
    public class Applicant : IApplicant
    {
        #region ApplicantEducation
        public void AddApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantEducationPoco>(createProxy: false);
            ApplicantEducationLogic bl = new ApplicantEducationLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantEducationPoco> GetAllApplicantEducation()
        {
            var repository = new EFGenericRepository<ApplicantEducationPoco>(createProxy: false);
            ApplicantEducationLogic bl = new ApplicantEducationLogic(repository);

            return bl.GetAll();
        }

        public ApplicantEducationPoco GetSingleApplicantEducation(string id)
        {
            var repository = new EFGenericRepository<ApplicantEducationPoco>(createProxy: false);
            ApplicantEducationLogic bl = new ApplicantEducationLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantEducationPoco>(createProxy: false);
            ApplicantEducationLogic bl = new ApplicantEducationLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantEducationPoco>(createProxy: false);
            ApplicantEducationLogic bl = new ApplicantEducationLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region ApplicantJobApplication
        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(createProxy: false);
            ApplicantJobApplicationLogic bl = new ApplicantJobApplicationLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(createProxy: false);
            ApplicantJobApplicationLogic bl = new ApplicantJobApplicationLogic(repository);

            return bl.GetAll();
        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string id)
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(createProxy: false);
            ApplicantJobApplicationLogic bl = new ApplicantJobApplicationLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(createProxy: false);
            ApplicantJobApplicationLogic bl = new ApplicantJobApplicationLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantJobApplicationPoco>(createProxy: false);
            ApplicantJobApplicationLogic bl = new ApplicantJobApplicationLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region ApplicantProfile
        public void AddApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(createProxy: false);
            ApplicantProfileLogic bl = new ApplicantProfileLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantProfilePoco> GetAllApplicantProfile()
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(createProxy: false);
            ApplicantProfileLogic bl = new ApplicantProfileLogic(repository);

            return bl.GetAll();
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(string id)
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(createProxy: false);
            ApplicantProfileLogic bl = new ApplicantProfileLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(createProxy: false);
            ApplicantProfileLogic bl = new ApplicantProfileLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>(createProxy: false);
            ApplicantProfileLogic bl = new ApplicantProfileLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region ApplicantResume
        public void AddApplicantResume(ApplicantResumePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(createProxy: false);
            ApplicantResumeLogic bl = new ApplicantResumeLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantResumePoco> GetAllApplicantResume()
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(createProxy: false);
            ApplicantResumeLogic bl = new ApplicantResumeLogic(repository);

            return bl.GetAll();
        }

        public ApplicantResumePoco GetSingleApplicantResume(string id)
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(createProxy: false);
            ApplicantResumeLogic bl = new ApplicantResumeLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantResume(ApplicantResumePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(createProxy: false);
            ApplicantResumeLogic bl = new ApplicantResumeLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantResume(ApplicantResumePoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantResumePoco>(createProxy: false);
            ApplicantResumeLogic bl = new ApplicantResumeLogic(repository);

            bl.Update(pocos);
        }
        #endregion

        #region ApplicantSkill
        public void AddApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(createProxy: false);
            ApplicantSkillLogic bl = new ApplicantSkillLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantSkillPoco> GetAllApplicantSkill()
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(createProxy: false);
            ApplicantSkillLogic bl = new ApplicantSkillLogic(repository);

            return bl.GetAll();
        }

        public ApplicantSkillPoco GetSingleApplicantSkill(string id)
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(createProxy: false);
            ApplicantSkillLogic bl = new ApplicantSkillLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(createProxy: false);
            ApplicantSkillLogic bl = new ApplicantSkillLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantSkillPoco>(createProxy: false);
            ApplicantSkillLogic bl = new ApplicantSkillLogic(repository);

            bl.Update(pocos);
        }
        #endregion
        
        #region ApplicantWorkHistory
        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantWorkHistoryPoco>(createProxy: false);
            ApplicantWorkHistoryLogic bl = new ApplicantWorkHistoryLogic(repository);

            bl.Add(pocos);
        }

        public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
        {
            var repository = new EFGenericRepository<ApplicantWorkHistoryPoco>(createProxy: false);
            ApplicantWorkHistoryLogic bl = new ApplicantWorkHistoryLogic(repository);

            return bl.GetAll();
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string id)
        {
            var repository = new EFGenericRepository<ApplicantWorkHistoryPoco>(createProxy: false);
            ApplicantWorkHistoryLogic bl = new ApplicantWorkHistoryLogic(repository);

            return bl.Get(Guid.Parse(id));
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantWorkHistoryPoco>(createProxy: false);
            ApplicantWorkHistoryLogic bl = new ApplicantWorkHistoryLogic(repository);

            bl.Delete(pocos);
        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            var repository = new EFGenericRepository<ApplicantWorkHistoryPoco>(createProxy: false);
            ApplicantWorkHistoryLogic bl = new ApplicantWorkHistoryLogic(repository);

            bl.Update(pocos);
        }
        #endregion
        
    }
}
