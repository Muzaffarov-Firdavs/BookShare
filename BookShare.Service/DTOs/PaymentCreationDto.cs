using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Service.DTOs
{
    public class PaymentCreationDto
    {
        public PaymentType Type { get; set; } = PaymentType.Cash;
        public bool IsPaid { get; set; } = false;
        public long BookOrderId { get; set; }

        public static implicit operator Payment(PaymentCreationDto paymentDto)
        {
            return new Payment()
            {
                Type = paymentDto.Type,
                IsPaid = paymentDto.IsPaid,
                BookOrderId = paymentDto.BookOrderId,
            };
        }
    }
}
