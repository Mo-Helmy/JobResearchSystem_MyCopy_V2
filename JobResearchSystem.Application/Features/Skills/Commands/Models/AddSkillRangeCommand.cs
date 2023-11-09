using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Commands.Models
{
    public class AddSkillRangeCommand : IRequest<BaseResponse<string>>
    {
        public int JobSeekerId { get; set; }

        public IEnumerable<AddSkillCommand> Skills { get; set; }

        //public class SkillInput
        //{
        //    public string SkillName { get; set; }
        //}
    }
}
