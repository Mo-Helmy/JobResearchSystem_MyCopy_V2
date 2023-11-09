using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");

            builder.Property(x => x.ExperienceCompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ExperienceTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PositionDescription)
                .IsRequired();


            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }


}
