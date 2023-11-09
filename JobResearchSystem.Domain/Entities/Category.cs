using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobResearchSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; } = new List<Job>();

        ////Self Relation
        //public int CategoryParentId { get; set; }
        //public ICollection<Category>? SubCategories { get; set; }

    }
}
