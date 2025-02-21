using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.User.post;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost("user-login")]
        [ProducesResponseType(typeof(UserRegisterResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public IActionResult Login(RequestLoginJson request) {

            try
            {

            var Login = new LoginUseCase();

            var response = Login.execute(request);

            return Ok(response);

            } catch (InvalidLoginException ex) {
                return Unauthorized(ex.Message);
            }
        }
    }
}
