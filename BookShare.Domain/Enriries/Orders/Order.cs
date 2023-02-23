using BookShare.Domain.Commons;

namespace BookShare.Domain.Enriries.Orders;

public class Order : Auditable
{
    public long BookId { get; set; }
    public long StudentId { get; set; }
    public long PaymentId { get; set; }
}
