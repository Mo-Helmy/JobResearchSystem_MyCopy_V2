namespace JobResearchSystem.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string SkillName { get; set; }

        public ICollection<JobSeeker> JobSeekers { get; set; }
    }
}
