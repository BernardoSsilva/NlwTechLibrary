using TechLibrary.Domain.entities;

namespace TechLibrary.Domain.repositories
{
    public interface ICheckoutRepository
    {
        public void Create(CheckoutEntity  checkout);

        public int CheckBookNotReturnedAmount(Guid bookId);
    }
}
