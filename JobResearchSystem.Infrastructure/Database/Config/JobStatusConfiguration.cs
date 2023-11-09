using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class JobStatusConfiguration : IEntityTypeConfiguration<JobStatus>
    {
        public void Configure(EntityTypeBuilder<JobStatus> builder)
        {
            builder.ToTable("JobStatuses");

            builder.Property(x => x.JobStatusName)
                .IsRequired();
        }
    }
}
