namespace JobResearchSystem.Application.Features.JobSeekers.Queries.Response
{
    public class JobSeekerResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CVFilePath { get; set; }
        public string? ImageFilePath { get; set; }

    }
}
