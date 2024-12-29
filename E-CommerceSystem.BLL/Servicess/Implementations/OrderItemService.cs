using AutoMapper;
using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.OrderItemDTO;
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
    public class OrderItemService : IOrderItemService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<OrderItem> _orderitemRepository;

        public OrderItemService(IMapper mapper, IUnitOfWork unitofwork, IRepository<OrderItem> orderitemRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _orderitemRepository = orderitemRepository;
        }

        public async Task<IResult> CreateAsync(OrderItemCreateDTO dto)
        {
            try
            {
                var orderitem = _mapper.Map<OrderItem>(dto);
                await _orderitemRepository.AddAsync(orderitem);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("OrderItem created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the orderitem,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create orderitem.");
            }
        }

        public Task<PagginatedResponse<OrderItemGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<OrderItemGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var orderitem = await _orderitemRepository.GetAsync(c => c.Id == id);
                if (orderitem == null)
                {
                    return new ErrorResult("Orderitem not found.");
                }
                await _orderitemRepository.RemoveAsync(orderitem);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Orderitem deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the orderitem with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete orderitem.");
            }
        }

        public async Task<IResult> UpdateAsync(int id, OrderItemUpdateDTO dto)
        {
            try
            {
                var orderitem = await _orderitemRepository.GetAsync(s => s.Id == id);
                if (orderitem == null)
                {
                    return new ErrorResult("Orderitem not found.");
                }
                _mapper.Map(dto, orderitem);
                await _orderitemRepository.UpdateAsync(orderitem);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Orderitem updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the orderitem with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update orderitem.");
            }
        }
    }
}
