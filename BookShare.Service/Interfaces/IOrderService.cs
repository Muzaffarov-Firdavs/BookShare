using BookShare.Domain.Enriries.Orders;
using BookShare.Service.DTOs;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreatAsync(OrderCreationDto orderCreationDto);
        public Task<bool> DeleteAsync(long id);
        public Task<OrderViewModel> GetByIdAsync(long id);
        public Task<List<OrderViewModel>> GetAllAsync();
    }
}
