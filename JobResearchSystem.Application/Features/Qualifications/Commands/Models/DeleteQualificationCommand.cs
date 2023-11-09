using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Models
{
    public class DeleteQualificationCommand : IRequest<BaseResponse<string>>
    {
        public int QualificationId { get; set; }
    }
}
