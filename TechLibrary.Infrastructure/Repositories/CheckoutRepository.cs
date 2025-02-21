using TechLibrary.Domain.entities;
using TechLibrary.Domain.repositories;

namespace TechLibrary.Infrastructure.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly TechLibraryDbContext dbContext;

        public int CheckBookNotReturnedAmount(Guid bookId)
        {
           return dbContext.Checkouts.Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);
        }

        public void Create(CheckoutEntity checkout)
        {
            dbContext.Checkouts.Add(checkout);
            dbContext.SaveChanges();
        }
    }
}
