#nullable disable

namespace JobResearchSystem.Application.DTOs.Authentication
{
    public class ResponseUserDetailsDto
    {
        public string Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }


        public string UserType { get; set; }

    }
}
