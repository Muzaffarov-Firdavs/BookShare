using BookShare.Domain.Commons;
using BookShare.Domain.Enriries.Orders;
using BookShare.Domain.Enums;

namespace BookShare.Domain.Enriries;

public class Payment : Auditable
{
    public PaymentType Type { get; set; } = PaymentType.Cash;
    public bool IsPaid { get; set; } = false;
    public long BookOrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
