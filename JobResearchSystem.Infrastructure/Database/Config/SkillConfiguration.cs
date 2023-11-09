using JobResearchSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Infrastructure.Database.Config
{
    internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            //builder.HasIndex(x => x.SkillName)
            //    .IsUnique();

            builder.Property(x => x.SkillName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
