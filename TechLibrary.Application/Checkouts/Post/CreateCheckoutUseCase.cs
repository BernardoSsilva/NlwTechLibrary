using TechLibrary.Domain.entities;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Repositories;

namespace TechLibrary.Application.Checkouts.Post
{
    public class CreateCheckoutUseCase
    {

        private const int max_days = 7;
      
        public void Execute(Guid bookId, Guid userId)
        {
            var repository = new CheckoutRepository();

            Validate(bookId);


            var entity = new CheckoutEntity
            {
                BookId = bookId,
                CheckoutDate = DateTime.UtcNow,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(max_days),
                UserId = userId
            };

            repository.Create(entity);
        }

        private void Validate(Guid bookId)
        {
            var booksRepository = new BookRepository();
            var bookExists = booksRepository.findById(bookId);

            if(bookExists is null)
            {
                throw new NotFoundException("book Not Found");
            }

            var checkoutRepository = new CheckoutRepository();

            var checkoutsAmount = checkoutRepository.CheckBookNotReturnedAmount(bookId);

            if (checkoutsAmount == bookExists.Amount)
            {
                throw new ConflictException("no books available");
            }
        }
    }
}
