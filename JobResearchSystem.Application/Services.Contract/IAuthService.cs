using JobResearchSystem.Application.DTOs.Authentication;

namespace JobResearchSystem.Application.IService
{
    public interface IAuthService
    {
        Task<AuthResponseModel> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseModel> RegisterAdminAsync(RegisterAdminDto model);
        Task<AuthResponseModel> LoginAsync(LoginDto loginDto);

        Task<IEnumerable<ResponseUserDetailsDto>> GetAllUsersAsync();
        Task<ResponseUserDetailsDto> GetUserByIdAsync(string id);

        Task<ResponseUserDetailsDto> UpdateUserAsync(UpdateUserDetailsDto Dto);

        Task DeleteUserAsync(string id);

        //ChangePassword
        Task<bool> ChangePassword(string userId, string password);
    }
}
