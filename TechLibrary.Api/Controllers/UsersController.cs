using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.User.post;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost("crate-user")]
        [ProducesResponseType(typeof(UserRegisterResponseJson), StatusCodes.Status201Created)]
        public IActionResult Create(UserRequestJson requestBody)
        {
            RegisterUserUseCase useCase = new RegisterUserUseCase();

            var response = useCase.execute(requestBody);
            return Created(string.Empty, response);
        }

        [HttpGet("/list")]
        public IActionResult GetAll()
        {
            return Created();
        }
    }


}



