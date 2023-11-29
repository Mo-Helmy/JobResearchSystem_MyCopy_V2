using AutoMapper;
using JobResearchSystem.Application.DTOs.Authentication;
using JobResearchSystem.Domain.Entities.Identity;

namespace JobResearchSystem.Application.Mapping.ApplicationUsers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            
            CreateMap<ApplicationUser, ResponseUserDetailsDto>()
                .ForMember(x => x.UserType, O => O.MapFrom(x => x.UserType.UserTypeName)); ;
            CreateMap<ApplicationUser, ResponseUserDto>()
                .ForMember(x => x.UserTypeName, O => O.MapFrom(x => x.UserType.UserTypeName));

            CreateMap<UpdateUserDetailsDto, ApplicationUser>();

        }
    }
}
