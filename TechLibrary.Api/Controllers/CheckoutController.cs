using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.service.LoggedUser;
using TechLibrary.Application.Checkouts.Post;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase
    {

        [HttpPost]
        [Route("{bookId}")]
        public IActionResult BookCheckout(Guid bookId)
        {
            var LoggedUser = new LoggedUserService(HttpContext);
            var useCase = new CreateCheckoutUseCase();

            useCase.Execute(bookId, Guid.Parse(LoggedUser.user()));

            return NoContent();
        }
    }
}
