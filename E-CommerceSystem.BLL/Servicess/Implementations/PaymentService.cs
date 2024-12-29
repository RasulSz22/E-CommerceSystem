using AutoMapper;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.PaymentDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.ErrorResults;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.SuccessResults;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Implementations
{
    public class PaymentService : IPaymentService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<Payment> _paymentRepository;

        public PaymentService(IMapper mapper, IUnitOfWork unitofwork, IRepository<Payment> paymentRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _paymentRepository = paymentRepository;
        }

        public async Task<IResult> CreateAsync(PaymentCreateDTO dto)
        {
            try
            {
                var payment = _mapper.Map<Payment>(dto);
                await _paymentRepository.AddAsync(payment);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Payment created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the payment,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create payment.");
            }
        }

        public Task<IDataResult<PaymentGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var payment = await _paymentRepository.GetAsync(c => c.Id == id);
                if (payment == null)
                {
                    return new ErrorResult("Payment not found.");
                }
                await _paymentRepository.RemoveAsync(payment);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Payment deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the payment with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete payment.");
            }
        }

        public async Task<IResult> UpdateAsync(int id, PaymentUpdateDTO dto)
        {
            try
            {
                var payment = await _paymentRepository.GetAsync(s => s.Id == id);
                if (payment == null)
                {
                    return new ErrorResult("Payment not found.");
                }
                _mapper.Map(dto, payment);
                await _paymentRepository.UpdateAsync(payment);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Payment updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the payment with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update payment.");
            }
        }
    }
}
