using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicants");

            builder.HasIndex(x => new { x.JobSeekerId, x.JobId })
               .IsUnique();

            builder.HasOne(x => x.JobSeeker)
                .WithMany(x => x.Applicants)
                .HasForeignKey(x => x.JobSeekerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.Applicants)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ApplicantStatus)
               .WithMany()
               .HasForeignKey(x => x.ApplicantStatusId)
               .OnDelete(DeleteBehavior.NoAction);


            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
