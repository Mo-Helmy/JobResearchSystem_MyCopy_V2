using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobResearchSystem.Domain.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? ApplicantsNumber { get; set; }
        // ToDo : add default value DateTime.Now in config
        public DateTime PublishDateTime { get; set; }
        public double? RangeSalaryMin { get; set; }
        public double? RangeSalaryMax { get; set; }

        // ToDo : add default value 1 in config
        public int JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
        public ICollection<Applicant>? Applicants { get; set; }
        public ICollection<JobSeeker>? JobSeekers { get; set; }
    }
}
