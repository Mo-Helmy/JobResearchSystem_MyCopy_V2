using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;

namespace JobResearchSystem.Application.Features.JobSeekers.Queries.Response
{
    public class JobSeekerDetailsResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CVFilePath { get; set; }
        public string? ImageFilePath { get; set; }

        public IReadOnlyList<ExperienceResponse>? Experiences { get; set; }
        public IReadOnlyList<QualificationResponse>? Qualifications { get; set; }
        public IReadOnlyList<SkillResponse>? Skills { get; set; }
    }
}
