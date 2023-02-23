using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Domain.Enums;


namespace BookShare.Service.ViewModels
{
    public class PaymentViewModel
    {
        public PaymentType Type { get; set; } = PaymentType.Cash;
        public bool IsPaid { get; set; } = false;
        public long BookOrderId { get; set; } = default!;

        public static implicit operator Payment(PaymentViewModel paymentViewModel)
        {
            return new Payment()
            {
                Type = paymentViewModel.Type,
                IsPaid = paymentViewModel.IsPaid,
                BookOrderId = paymentViewModel.BookOrderId,
            };
        }
    }
}
