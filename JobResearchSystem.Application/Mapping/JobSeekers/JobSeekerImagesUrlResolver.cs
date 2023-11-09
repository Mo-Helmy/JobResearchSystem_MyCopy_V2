using AutoMapper;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Api.Helpers
{
    public class JobSeekerImagesUrlResolver : IValueResolver<JobSeeker, JobSeekerResponse, string>,
                                            IValueResolver<JobSeeker, JobSeekerDetailsResponse, string>
    {
        private readonly IConfiguration _configuration;
        public JobSeekerImagesUrlResolver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Resolve(JobSeeker source, JobSeekerResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageFilePath))
                return $"{_configuration.GetSection("ApiBaseUrl").Value}JobSeekerData/ProfileImages/{source.ImageFilePath}";

            return string.Empty;
        }

        public string Resolve(JobSeeker source, JobSeekerDetailsResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageFilePath))
                return $"{_configuration.GetSection("ApiBaseUrl").Value}JobSeekerData/ProfileImages/{source.ImageFilePath}";

            return string.Empty;
        }
    }
}
