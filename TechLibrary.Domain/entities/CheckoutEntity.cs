namespace TechLibrary.Domain.entities
{
    public class CheckoutEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CheckoutDate { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
