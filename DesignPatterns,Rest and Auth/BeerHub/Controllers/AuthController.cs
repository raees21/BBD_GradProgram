using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeerHub.Utils;
using BeerHub.Enums;
using BeerHub.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BeerHub.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate a JWT token for development use
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "type": "Seller"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAuthenticate(FakeAuthRequest fakeAuthRequest)
        {
            string fakeToken = TokenGenerator.GenerateJWT(fakeAuthRequest, _configuration["JWT:Secret"]);
            return StatusCode(201, fakeToken);
        }
    }
}
