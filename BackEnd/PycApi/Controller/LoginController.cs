using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Service;

namespace PycApi.Controller
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public LoginController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return (response.Success == false) ? BadRequest(response) : Ok(response.Response);
        }
    }
}
