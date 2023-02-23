using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries.Orders;
using BookShare.Service.Commons;
using BookShare.Service.DTOs;
using BookShare.Service.Interfaces;
using BookShare.Service.ViewModels;
using Org.BouncyCastle.Asn1.X509;

namespace BookShare.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly GenericRepository<Order> _repository;

         
        public OrderService(GenericRepository<Order> genericRepository)
        {

            this._repository = genericRepository;
        }
        public async Task<Order> CreatAsync(OrderCreationDto orderCreationDto)
        {
            var order = (Order)orderCreationDto;
            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;

           var respond = await this._repository.CreateAsync(order);
            return respond;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var order = await this._repository.GetByIdAsync(id);
            if (order is not null)
            {
                await this._repository.DeleteAsync(id);
            }

            throw new NotFoundException("order not found");
        }

        public  async Task<List<OrderViewModel>> GetAllAsync()
        {
            var orders = await this._repository.GetAllAsync();

           List<OrderViewModel> models= new List<OrderViewModel>();

            OrderViewModel orderViewModel = new OrderViewModel();
            foreach (var order in orders)
            {
                orderViewModel.BookId = order.BookId;
                orderViewModel.StudentId = order.StudentId;
                orderViewModel.Payment = order.Payment;

                models.Add(orderViewModel);
            }
            return models;
            
        }

        public async Task<OrderViewModel> GetByIdAsync(long id)
        {
            var order =  await this._repository.GetByIdAsync(id);
            if (order is null)
            {
                throw new NotFoundException("Order Not found");
            }
            OrderViewModel orderViewModel = new OrderViewModel();

            orderViewModel.BookId = order.BookId;
            orderViewModel.StudentId = order.StudentId;
            orderViewModel.Payment = order.Payment;

            return orderViewModel;

        }

        
    }
}
