using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Models
{
    public class AddExperienceCommand : IRequest<BaseResponse<ExperienceResponse>>
    {
        public string ExperienceCompanyName { get; set; }

        public string ExperienceTitle { get; set; }

        public DateTime? ExperienceStartDate { get; set; }
        public DateTime? ExperienceEndDate { get; set; }

        public string? PositionDescription { get; set; }

        public int JobSeekerId { get; set; }
    }
}
