using Application.Services;
using Application.UseCases.Admin.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(InputDtoGenerateTokenAdmin model)
        {
            var response = _adminService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Mail or password is incorrect" });

            return Ok(response);
        }
    }
}