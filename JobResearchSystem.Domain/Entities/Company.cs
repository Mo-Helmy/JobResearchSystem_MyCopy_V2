using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JobResearchSystem.Domain.Entities.Identity;

namespace JobResearchSystem.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public int NumberOfJobs { get; set; } //perMonth
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; } = new List<Job>();
    }
}
