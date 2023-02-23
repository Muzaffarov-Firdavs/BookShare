using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Service.ViewModels
{
    public class OrderViewModel
    {
        public long BookId { get; set; } 
        public long StudentId { get; set; }
        public long PaymentId { get; set; } = default!;

        public static implicit operator Order(OrderViewModel orderCreationDto)
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
