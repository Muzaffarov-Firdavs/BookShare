using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Service.DTOs;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Interfaces;

public interface IPaymentService 
{
    public Task<Payment> CreatAsync(PaymentCreationDto paymentCreationDto);
    public Task<bool> DeleteAsync(long id);
    public Task<PaymentViewModel> GetByIdAsync(long id);
    public Task<List<PaymentViewModel>> GetAllAsync();
}
