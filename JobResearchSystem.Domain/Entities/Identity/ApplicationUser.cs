using Microsoft.AspNetCore.Identity;

namespace JobResearchSystem.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }


        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
