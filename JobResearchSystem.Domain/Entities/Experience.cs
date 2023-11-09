using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobResearchSystem.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public string ExperienceCompanyName { get; set; }
        public string ExperienceTitle { get; set; }
        public DateTime? ExperienceStartDate { get; set; }
        public DateTime? ExperienceEndDate { get; set; }
        public string? PositionDescription { get; set; }

        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
    }
}
