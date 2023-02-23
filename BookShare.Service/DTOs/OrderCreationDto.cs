using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;

namespace BookShare.Service.DTOs
{
    public class OrderCreationDto
    { 
        public long BookId { get; set; } 
        public long StudentId { get; set; }
        public long PaymentId { get; set; } = default!;

        public static implicit operator Order(OrderCreationDto orderCreationDto)
        {
            return new Order()
            {
                BookId = orderCreationDto.BookId,
                StudentId = orderCreationDto.StudentId,
                PaymentId = orderCreationDto.PaymentId,
            };
        }
    }
}
