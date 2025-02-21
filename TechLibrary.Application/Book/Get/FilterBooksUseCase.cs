using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Infrastructure.Repositories;

namespace TechLibrary.Application.Book.Get
{
    public class FilterBooksUseCase
    {
        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var repository = new BookRepository();


            var response = repository.filterBooks(request.PageNumber, request.Title);

            return new ResponseBooksJson
            {
                Pagination = new ResponsePaginationJson
                {
                    PageNumber = request.PageNumber,
                    TotalCount = repository.CountBooks(request.Title)
                },
                Books = response.Select(book => new ResponseBookJson
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author
                }).ToList(),
            };
        }
    }
}
