using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Models
{
    public class DeleteExperienceCommand : IRequest<BaseResponse<string>>
    {
        public int ExperienceId { get; set; }
    }
}
