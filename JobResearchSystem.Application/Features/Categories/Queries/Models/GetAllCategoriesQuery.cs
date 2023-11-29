using JobResearchSystem.Application.Features.Categories.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Categories.Queries.Models
{
    public class GetAllCategoriesQuery : IRequest<BaseResponse<IEnumerable<GetCategoryResponse>>>
    {
    }
}
