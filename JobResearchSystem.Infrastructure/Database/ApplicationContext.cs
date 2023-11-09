using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobResearchSystem.Infrastructure.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        #region DbSets

        public DbSet<Applicant> Applicants { get; set; } = null!;
        public DbSet<ApplicantStatus> ApplicantStatuses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<JobSeeker> JobSeekers { get; set; } = null!;
        public DbSet<JobStatus> JobStatuses { get; set; } = null!;
        public DbSet<Qualification> Qualifications { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<UserType> UserTypes { get; set; } = null!;

        #endregion

        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        override protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
