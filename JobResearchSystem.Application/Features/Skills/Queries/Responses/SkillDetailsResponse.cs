namespace JobResearchSystem.Application.Features.Skills.Queries.Responses
{
    public class SkillDetailsResponse
    {
        public int Id { get; set; }
        public string SkillName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
