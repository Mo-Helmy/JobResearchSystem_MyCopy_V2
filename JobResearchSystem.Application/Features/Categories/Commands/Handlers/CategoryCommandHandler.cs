using AutoMapper;
using JobResearchSystem.Application.Features.Categories.Commands.Models;
using JobResearchSystem.Application.Features.Categories.Queries.Response;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Features.Categories.Commands.Handlers
{
    public class CategoryCommandHandler : ResponseHandler,
                                       IRequestHandler<AddCategoryCommand, BaseResponse<GetCategoryResponse>>,
                                       IRequestHandler<DeleteCategoryCommand, BaseResponse<string>>,
                                       IRequestHandler<UpdateCategoryCommand, BaseResponse<GetCategoryResponse>>
    {
        #region CTOR
        private IGenericService<Category> _CategoryService;
        private IMapper _mapper;

        public CategoryCommandHandler(IGenericService<Category> CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<GetCategoryResponse>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request);
            var createdEntity = await _CategoryService.CreateAsync(entity);

            if (createdEntity is null)
                return BadRequest<GetCategoryResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<GetCategoryResponse>(createdEntity);

            return Created(mappedEntity);
        }

        public async Task<BaseResponse<GetCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _CategoryService.UpdateAsync(request.Id, request);

            if (updatedEntity is null)
                return BadRequest<GetCategoryResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<GetCategoryResponse>(updatedEntity);
            
            return Success<GetCategoryResponse>(mappedEntity);
        }




        public async Task<BaseResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _CategoryService.DeleteAsync(request.CategoryId);

            if (!result)
                return BadRequest<string>("");

            return Deleted<string>("");
        }

    }
}
