using System.ComponentModel.DataAnnotations;

namespace JobResearchSystem.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        // common attributes
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}


