using JobResearchSystem.Application.DTOs.Authentication;
using JobResearchSystem.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobResearchSystem.API.Controllers
{
   
    public class AdminController : ApiBaseController
    {
        private readonly IAuthService _authService;

        public AdminController(IAuthService authService)
        {
            this._authService = authService;
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost("AddAdmin")]
        public async Task<ActionResult<AuthResponseModel>> CreateAdminAccount(RegisterAdminDto registerDto)
        {
            var userResponse = await _authService.RegisterAdminAsync(registerDto);

            return Ok(userResponse);
        }
    }
}
