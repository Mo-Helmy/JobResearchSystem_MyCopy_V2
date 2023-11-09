using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Address)
                .IsRequired();

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Website)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Company>(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }


}
