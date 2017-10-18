using System;
using System.Collections.Generic;
using System.Data.Entity;
using CareerCloud.Pocos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.Web.Configuration;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext() : this(false)
        {}

        public CareerCloudContext(bool createProxy = true) : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
            this.Database.Log = t => Debug.WriteLine(t);
            Configuration.ProxyCreationEnabled = createProxy;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SystemCountryCodes
            modelBuilder.Entity<SystemCountryCodePoco>()
                        .HasMany(e => e.ApplicantProfiles)
                        .WithRequired(e => e.SystemCountryCodes)
                        .HasForeignKey(e => e.Country);

            modelBuilder.Entity<SystemCountryCodePoco>()
                        .HasMany(e => e.ApplicantWorkHistory)
                        .WithRequired(e => e.SystemCountryCodes)
                        .HasForeignKey(e => e.CountryCode);
            #endregion

            #region CompanyProfiles
            modelBuilder.Entity<CompanyProfilePoco>()
                        .HasMany(e => e.CompanyDescriptions)
                        .WithRequired(e => e.CompanyProfiles)
                        .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                        .HasMany(e => e.CompanyJobs)
                        .WithRequired(e => e.CompanyProfiles)
                        .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                        .HasMany(e => e.CompanyLocations)
                        .WithRequired(e => e.CompanyProfiles)
                        .HasForeignKey(e => e.Company);
            #endregion

            #region CompanyJobs
            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany(e => e.ApplicantJobApplications)
                        .WithRequired(e => e.CompanyJobs)
                        .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany(e => e.CompanyJobEducation)
                        .WithRequired(e => e.CompanyJobs)
                        .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany(e => e.CompanyJobSkills)
                        .WithRequired(e => e.CompanyJobs)
                        .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany(e => e.CompanyJobDescriptions)
                        .WithRequired(e => e.CompanyJobs)
                        .HasForeignKey(e => e.Job);
            #endregion

            #region SecurityRoles
            modelBuilder.Entity<SecurityRolePoco>()
                        .HasMany(e => e.SecurityLoginsRoles)
                        .WithRequired(e => e.SecurityRoles)
                        .HasForeignKey(e => e.Role);
            #endregion

            #region SecurityLogins
            modelBuilder.Entity<SecurityLoginPoco>()
                        .HasMany(e => e.ApplicantProfiles)
                        .WithRequired(e => e.SecurityLogins)
                        .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                        .HasMany(e => e.SecurityLoginsLogs)
                        .WithRequired(e => e.SecurityLogins)
                        .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                        .HasMany(e => e.SecurityLoginsRoles)
                        .WithRequired(e => e.SecurityLogins)
                        .HasForeignKey(e => e.Login);
            #endregion

            #region ApplicantProfiles
            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany(e => e.ApplicantEducation)
                        .WithRequired(e => e.ApplicantProfiles)
                        .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany(e => e.ApplicantJobApplications)
                        .WithRequired(e => e.ApplicantProfiles)
                        .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany(e => e.ApplicantSkills)
                        .WithRequired(e => e.ApplicantProfiles)
                        .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany(e => e.ApplicantWorkHistory)
                        .WithRequired(e => e.ApplicantProfiles)
                        .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany(e => e.ApplicantResumes)
                        .WithRequired(e => e.ApplicantProfiles)
                        .HasForeignKey(e => e.Applicant);
            #endregion
                        
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }
    }
}
