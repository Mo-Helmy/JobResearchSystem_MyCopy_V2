using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Commands.Models
{
    public class DeleteSkillCommand : IRequest<BaseResponse<string>>
    {
        public int SkillId { get; set; }
    }
}
