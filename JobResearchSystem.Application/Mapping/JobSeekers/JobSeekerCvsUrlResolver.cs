using AutoMapper;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Api.Helpers
{
    public class JobSeekerCvsUrlResolver : IValueResolver<JobSeeker, JobSeekerResponse, string>,
                                            IValueResolver<JobSeeker, JobSeekerDetailsResponse, string>
    {
        private readonly IConfiguration _configuration;
        public JobSeekerCvsUrlResolver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Resolve(JobSeeker source, JobSeekerResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CVFilePath))
                return $"{_configuration.GetSection("ApiBaseUrl").Value}JobSeekerData/Cvs/{source.CVFilePath}";

            return string.Empty;
        }

        public string Resolve(JobSeeker source, JobSeekerDetailsResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CVFilePath))
                return $"{_configuration.GetSection("ApiBaseUrl").Value}JobSeekerData/Cvs/{source.CVFilePath}";

            return string.Empty;
        }
    }
}
