using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class JobSeekersConfiguration : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.ToTable("JobSeekers");

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<JobSeeker>(x => x.UserId);

            builder.HasMany(x => x.Skills)
                .WithMany(x => x.JobSeekers);

            builder.HasMany(x => x.Experiences)
                .WithOne(x => x.JobSeeker)
                .HasForeignKey(x => x.JobSeekerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Qualifications)
                .WithOne(x => x.JobSeeker)
                .HasForeignKey(x => x.JobSeekerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Jobs)
                .WithMany(x => x.JobSeekers)
                .UsingEntity<Applicant>();


            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
