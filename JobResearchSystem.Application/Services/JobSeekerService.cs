using Azure.Core;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Application.Specifications.JobSeekerSpecifications;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using System.ComponentModel.DataAnnotations;

namespace JobResearchSystem.Application.Services
{
    public class JobSeekerService : GenericService<JobSeeker>, IJobSeekerService
    {
        public JobSeekerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IReadOnlyList<JobSeeker>> GetAllJobSeekerPaginationAsync(GetAllJobSeekersQuery query)
        {
            var jobSeekerSpecification = new JobSeekerSpecifications(query);

            var entityList = await _unitOfWork.GetRepository<JobSeeker>().GetAllWithSpecAsync(jobSeekerSpecification);

            return entityList;
        }

        public async Task<int> GetAllJobSeekerPaginationCountAsync(GetAllJobSeekersQuery query)
        {
            var jobSeekerSpecification = new JobSeekerCountSpecifications(query);

            var totalCount = await _unitOfWork.GetRepository<JobSeeker>().GetCountWithSpecAsync(jobSeekerSpecification);

            return totalCount;
        }

        public override async Task<JobSeeker?> GetByIdAsync(int id)
        {
            var jobSeekerSpec = new BaseSpecification<JobSeeker>(x => x.Id == id) 
            {
                Includes = new List<System.Linq.Expressions.Expression<Func<JobSeeker, object>>> ()
                {
                    x => x.User,
                    x => x.Skills,
                    x => x.Experiences,
                    x => x.Qualifications,
                }
            };

            var entity = await _unitOfWork.GetRepository<JobSeeker>().GetByIdWithSpecAsync(jobSeekerSpec);

            return entity;
        }

        public async Task<JobSeeker?> UpdateJobSeekerAsync(UpdateJobSeekerCommand command)
        {
            var existingJobSeeker = await _unitOfWork.GetRepository<JobSeeker>().GetByIdAsync(command.Id);

            if (existingJobSeeker == null)
            {
                throw new KeyNotFoundException("This Id Doesn't Exist in DB");
            }


            if (command.ImageForm != null)//Update Image
            {
                if (existingJobSeeker.ImageFilePath != null)
                {
                    await Helper.HandelFiles.RemoveFile(existingJobSeeker.ImageFilePath, "image"); // remove old Image
                }

                var myTuple = await Helper.HandelFiles.UploadFile(command.ImageForm); // Add the New Image

                if (myTuple.Item1)
                {
                    existingJobSeeker.ImageFilePath = myTuple.Item2;
                }
                else
                    throw new ValidationException(myTuple.Item2);
            }

            if (command.CvForm != null)//Update Cv
            {
                if (existingJobSeeker.CVFilePath != null)
                {
                    await Helper.HandelFiles.RemoveFile(existingJobSeeker.CVFilePath, "cv"); // remove old Image
                }

                var myTuple = await Helper.HandelFiles.UploadFile(command.CvForm); // Add the New Image

                if (myTuple.Item1)
                {
                    existingJobSeeker.CVFilePath = myTuple.Item2;
                }
                else
                    throw new ValidationException(myTuple.Item2);
            }
            var count = await _unitOfWork.Complete();

            return count > 0 ? existingJobSeeker : null;
        }
    }
}
