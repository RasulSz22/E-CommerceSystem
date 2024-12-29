using AutoMapper;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.OrderDTO;
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
    public class OrderService : IOrderService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<Order> _orderRepository;

        public OrderService(IMapper mapper, IUnitOfWork unitofwork, IRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _orderRepository = orderRepository;
        }

        public async Task<IResult> CreateAsync(OrderCreateDTO dto)
        {
            try
            {
                var order = _mapper.Map<Order>(dto);
                await _orderRepository.AddAsync(order);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Order created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the order,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create order.");
            }
        }

        public Task<IDataResult<OrderGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var order = await _orderRepository.GetAsync(c => c.Id == id);
                if (order == null)
                {
                    return new ErrorResult("Order not found.");
                }
                await _orderRepository.RemoveAsync(order);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the order with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete order.");
            }
        }

        public async Task<IResult> UpdateAsync(int id, OrderUpdateDTO dto)
        {
            try
            {
                var order = await _orderRepository.GetAsync(s => s.Id == id);
                if (order == null)
                {
                    return new ErrorResult("Order not found.");
                }
                _mapper.Map(dto, order);
                await _orderRepository.UpdateAsync(order);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Order updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the order with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update order.");
            }
        }
    }
}
