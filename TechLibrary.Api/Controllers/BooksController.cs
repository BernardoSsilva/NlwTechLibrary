using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Book.Get;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("filter")]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBooksUseCase();

            var request = new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            };

            var result = useCase.Execute(request);

            if(result.Books.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
