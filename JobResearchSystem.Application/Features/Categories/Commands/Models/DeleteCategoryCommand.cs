using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Categories.Commands.Models
{
    public class DeleteCategoryCommand : IRequest<BaseResponse<string>>
    {
        public int CategoryId { get; set; }
    }
}
