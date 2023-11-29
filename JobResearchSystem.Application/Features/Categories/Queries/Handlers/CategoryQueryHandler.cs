using AutoMapper;
using JobResearchSystem.Application.Features.Categories.Queries.Models;
using JobResearchSystem.Application.Features.Categories.Queries.Response;
using JobResearchSystem.Application.IService;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Features.Categories.Queries.Handlers
{
    public class CategoryQueryHandler : ResponseHandler,
                                     IRequestHandler<GetAllCategoriesQuery, BaseResponse<IEnumerable<GetCategoryResponse>>>
    {
        #region CTOR
        private IGenericService<Category> _CategoryService;
        private IMapper _mapper;

        public CategoryQueryHandler(IGenericService<Category> CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<IEnumerable<GetCategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _CategoryService.GetAllAsync();
            if (entitiesList == null)
                return NotFound<IEnumerable<GetCategoryResponse>>();

            var ListMapped = _mapper.Map<IEnumerable<GetCategoryResponse>>(entitiesList);

            return Success(ListMapped);


        }
    }
}
