namespace JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse
{
    public class ExperienceResponse
    {
        public int Id { get; set; }
        public string ExperienceCompanyName { get; set; }

        public string ExperienceTitle { get; set; }

        public DateTime? ExperienceStartDate { get; set; }
        public DateTime? ExperienceEndDate { get; set; }

        public string? PositionDescription { get; set; }

        public int JobSeekerId { get; set; }

    }
}
