#nullable disable

using System.ComponentModel.DataAnnotations;

namespace JobResearchSystem.Application.DTOs.Authentication
{
    public class UpdateUserDetailsDto
    {
        [Required]
        public string Id { get; set; }
        
        public string? FirstName {  get; set; }
        
        public string? LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }
}
