using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobResearchSystem.Domain.Entities.Identity;

namespace JobResearchSystem.Domain.Entities
{
    public class JobSeeker : BaseEntity
    {
        public string? CVFilePath { get; set; }
        public string? ImageFilePath { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Skill> Skills { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }

        public ICollection<Applicant> Applicants { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
