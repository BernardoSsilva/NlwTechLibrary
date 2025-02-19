using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.User.post;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost("crate-user")]
        [ProducesResponseType(typeof(UserRegisterResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Create(UserRequestJson requestBody)
        {
            try
            {

            RegisterUserUseCase useCase = new RegisterUserUseCase();

            var response = useCase.execute(requestBody);
            return Created(string.Empty, response);
            }
            catch (TechLibraryException error) {
                return BadRequest(new ResponseErrorMessagesJson
                {
                    Errors = error.getErrorMessages()
                });

            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
                {
                    Errors =["Unknown error"]
                });
            }
        }

        [HttpGet("/list")]
        public IActionResult GetAll()
        {
            return Created();
        }
    }


}



