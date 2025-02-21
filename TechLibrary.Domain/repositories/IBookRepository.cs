using TechLibrary.Domain.entities;

namespace TechLibrary.Domain.repositories
{
    public interface IBookRepository
    {
        List<BookEntity> filterBooks(int page, string? title);

        int CountBooks(string? title);

        BookEntity? findById(Guid bookId);
    }
}
