using JobResearchSystem.Application.Features.Categories.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<BaseResponse<GetCategoryResponse>>
    {
        public string CategoryName { get; set; }
        //public int CategoryParentId { get; set; }
        public string? Description { get; set; }

    }
}
