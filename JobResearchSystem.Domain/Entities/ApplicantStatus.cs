using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobResearchSystem.Domain.Entities
{
    public class ApplicantStatus : BaseEntity
    {
        public string ApplicantStatusName { get; set; }
    }
}
