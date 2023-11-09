using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobResearchSystem.Domain.Entities
{
    public class BaseEntityDetails : BaseEntity
    {
        // common attributes
        public DateTime DateCreated { get; set; } 
        public bool IsDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}


