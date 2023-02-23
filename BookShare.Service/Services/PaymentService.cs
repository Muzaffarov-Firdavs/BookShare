using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Service.Commons;
using BookShare.Service.DTOs;
using BookShare.Service.Interfaces;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly GenericRepository<Payment> _genericRepository;

        public PaymentService(GenericRepository<Payment> genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task<Payment> CreatAsync(PaymentCreationDto paymentCreationDto)
        {

            var mapped = new Payment()
            {
                Type = paymentCreationDto.Type,
                BookOrderId = paymentCreationDto.BookOrderId,
                IsPaid = paymentCreationDto.IsPaid,

            };
           var result = await this._genericRepository.CreateAsync(mapped);
            return result;

        }

        public async Task<bool> DeleteAsync(long id)
        {
            var model = await this._genericRepository.GetByIdAsync(id);
            if (model is null)
            {
                throw new NotFoundException("Payment not found: ");
            }

            return true;
        }

        public async Task<List<PaymentViewModel>> GetAllAsync()
        {
            var payments = await this._genericRepository.GetAllAsync();
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            List<PaymentViewModel> result = new List<PaymentViewModel>();

            foreach (var payment in payments)
            {
                paymentViewModel.BookOrderId = payment.BookOrderId;
                paymentViewModel.IsPaid= payment.IsPaid;
                paymentViewModel.Type= payment.Type;

                result.Add(paymentViewModel);

            }
            return result;

        }

        public async Task<PaymentViewModel> GetByIdAsync(long id)
        {
            var payment = await this._genericRepository.GetByIdAsync(id);
            if (payment is null)
            {
                throw new NotFoundException("User not found");
            }

            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.BookOrderId = payment.BookOrderId;
            paymentViewModel.Type = payment.Type;
            paymentViewModel.IsPaid= payment.IsPaid;

            return paymentViewModel;
        }
    }
}
