using JobResearchSystem.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(x => x.UserType)
                .WithMany()
                .HasForeignKey(x => x.UserTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
