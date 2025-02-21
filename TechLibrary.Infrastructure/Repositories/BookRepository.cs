using TechLibrary.Domain.entities;
using TechLibrary.Domain.repositories;

namespace TechLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly TechLibraryDbContext dbContext;

        private const int perPage = 10;
        public int CountBooks(string? title)
        {

            if (!string.IsNullOrWhiteSpace(title)) return dbContext.Books.Where(book => book.Title.Contains(title)).Count();

            return dbContext.Books.Count();
        }

        public List<BookEntity> filterBooks(int page, string? title)
        {

            var query = dbContext.Books.AsQueryable();


            if (!string.IsNullOrWhiteSpace(title)) query = dbContext.Books.Where(book => book.Title.Contains(title));
            
            return query.OrderBy(book => book.Title)
               .ThenBy(book => book.Author)
               .Skip((page - 1) * perPage)
               .Take(perPage)
               .ToList(); 
        }

        public BookEntity?  findById(Guid bookId)
        {
            return dbContext.Books.FirstOrDefault(book => book.Id == bookId);
        }
    }
}
