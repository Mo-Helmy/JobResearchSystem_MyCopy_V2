using AutoMapper;
using JobResearchSystem.Application.Features.Categories.Commands.Models;
using JobResearchSystem.Application.Features.Categories.Queries.Response;
using JobResearchSystem.Domain.Entities;

namespace JobResearchSystem.Application.Mapping.Experiences
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Category, GetCategoryResponse>();

            CreateMap<AddCategoryCommand, Category>();

            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<DeleteCategoryCommand, GetCategoryResponse>();

        }
    }
}
