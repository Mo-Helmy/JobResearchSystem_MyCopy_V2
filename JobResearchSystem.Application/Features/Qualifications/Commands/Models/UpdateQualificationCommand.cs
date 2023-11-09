using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Models
{
    public class UpdateQualificationCommand : IRequest<BaseResponse<QualificationResponse>>
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string? Degree { get; set; }
        public string? FieldOfStudy { get; set; }
        public decimal? Duration { get; set; }
        public DateTime? QualificationStartDate { get; set; }
        public DateTime? QualificationEndDate { get; set; }

        public decimal? Grade { get; set; }
        public string? QualificationDescription { get; set; }
    }
}
