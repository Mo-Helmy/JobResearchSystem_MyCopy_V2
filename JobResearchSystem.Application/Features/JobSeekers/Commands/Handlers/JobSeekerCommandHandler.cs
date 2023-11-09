using AutoMapper;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Helper;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Feature.JobSeekers.Commands.Handlers
{
    public class JobSeekerCommandHandler : ResponseHandler,
                                           IRequestHandler<AddJobSeekerCommand, BaseResponse<JobSeekerResponse>>,
                                           IRequestHandler<DeleteJobSeekerCommand, BaseResponse<string>>,
                                           IRequestHandler<UpdateJobSeekerCommand, BaseResponse<JobSeekerResponse>>
    {
        #region CTOR
        private IJobSeekerService _jobSeekerService;
        private IMapper _mapper;

        public JobSeekerCommandHandler(IJobSeekerService jobSeekerService, IMapper mapper)
        {
            _jobSeekerService = jobSeekerService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<JobSeekerResponse>> Handle(AddJobSeekerCommand request, CancellationToken cancellationToken)
        {
            var jobSeeker = _mapper.Map<JobSeeker>(request);

            //var jobSeeker = new JobSeeker();
            //jobSeeker.UserId = request.UserId;

            //upload image  
            if (request.ImageForm != null)
            {
                var myTuple = await HandelFiles.UploadFile(request.ImageForm);  // Add the New Image

                if (myTuple.Item1)
                {
                    jobSeeker.ImageFilePath =myTuple.Item2;
                }
                else
                    return BadRequest<JobSeekerResponse>(myTuple.Item2);
            }

            //upload Cv  
            if (request.CvForm != null)
            {
                var myTuple = await HandelFiles.UploadFile(request.CvForm);  // Add the New Cv

                if (myTuple.Item1)
                {
                    jobSeeker.CVFilePath = myTuple.Item2;
                }
                else
                    return BadRequest<JobSeekerResponse>(myTuple.Item2);
            }

            var createdJobSeeker = await _jobSeekerService.CreateAsync(jobSeeker);

            if (createdJobSeeker is null)
                return BadRequest<JobSeekerResponse>("Something Went Wrong");

            var mappedCreatedJobSeeker = _mapper.Map<JobSeekerResponse>(createdJobSeeker);

            return Created(mappedCreatedJobSeeker);
        }

        public async Task<BaseResponse<JobSeekerResponse>> Handle(UpdateJobSeekerCommand request, CancellationToken cancellationToken)
        {
            var existingJobSeeker = await _jobSeekerService.GetByIdAsync(request.Id);

            if (existingJobSeeker == null)
            {
                return NotFound<JobSeekerResponse>("This Id Doesn't Exist in DB");
            }

            var jobSeeker = _mapper.Map<JobSeeker>(request);

            if (request.ImageForm != null)//Update Image
            {
                if (existingJobSeeker.ImageFilePath != null)
                {
                    await Helper.HandelFiles.RemoveFile(existingJobSeeker.ImageFilePath, "image"); // remove old Image
                }

                var myTuple = await Helper.HandelFiles.UploadFile(request.ImageForm); // Add the New Image

                if (myTuple.Item1)
                {
                    jobSeeker.ImageFilePath = myTuple.Item2;
                }
                else
                    return BadRequest<JobSeekerResponse>(myTuple.Item2);
            }

            if (request.CvForm != null)//Update Cv
            {
                if (existingJobSeeker.CVFilePath != null)
                {
                    await Helper.HandelFiles.RemoveFile(existingJobSeeker.CVFilePath, "cv"); // remove old Image
                }

                var myTuple = await Helper.HandelFiles.UploadFile(request.CvForm); // Add the New Image

                if (myTuple.Item1)
                {
                    jobSeeker.CVFilePath = myTuple.Item2;
                }
                else
                    return BadRequest<JobSeekerResponse>(myTuple.Item2);
            }

            var result = await _jobSeekerService.UpdateAsync(jobSeeker);

            var resultDto = _mapper.Map<JobSeekerResponse>(result);

            if (resultDto == null)  return BadRequest<JobSeekerResponse>("");

            return Success<JobSeekerResponse>(resultDto); 
        }

        public async Task<BaseResponse<string>> Handle(DeleteJobSeekerCommand request, CancellationToken cancellationToken)
        {
            var existingJobSeeker = await _jobSeekerService.GetByIdAsync(request.JobSeekerId);

            if (existingJobSeeker == null)
            {
                return NotFound<string>("This Id Doesn't Exist in DB");
            }

            if (existingJobSeeker.ImageFilePath != null)
            {
                await HandelFiles.RemoveFile(existingJobSeeker.ImageFilePath, "image"); // remove Image
            }

            if (existingJobSeeker.CVFilePath != null)
            {
                await HandelFiles.RemoveFile(existingJobSeeker.CVFilePath, "cv"); // remove Cv
            }

            var result = await _jobSeekerService.DeleteAsync(request.JobSeekerId);

            if (!result)
                return BadRequest<string>("");

            return Deleted<string>("");
        }

    }

}




