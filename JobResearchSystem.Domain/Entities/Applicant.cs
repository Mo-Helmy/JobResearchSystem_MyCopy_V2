namespace JobResearchSystem.Domain.Entities
{
    public class Applicant : BaseEntity
    {
        public int JobId { get; set; }
        public Job Job { get; set; }

        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }

        // TODO configure statusId = 1 in first creation
        public int ApplicantStatusId { get; set; }
        public ApplicantStatus ApplicantStatus { get; set; }
    }
}
