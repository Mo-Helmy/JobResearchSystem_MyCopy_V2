using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class ApplicantStatusConfiguration : IEntityTypeConfiguration<ApplicantStatus>
    {
        public void Configure(EntityTypeBuilder<ApplicantStatus> builder)
        {
            builder.ToTable("ApplicantStatuses");

            builder.Property(x => x.ApplicantStatusName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
