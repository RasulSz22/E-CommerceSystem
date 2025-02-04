using AutoMapper;
using E_CommerceSystem.BLL.Extentions;
using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IOrderItemRepository;
using E_CommerceSystem.DAL.Abstract.IProductRepository;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.DTOs.OrderItemDTO;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.ErrorResults;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.SuccessResults;
using Microsoft.EntityFrameworkCore;
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
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemGetDTO>> GetAllAsync()
        {
            var orderItems = await _orderItemRepository.GetListAsync(x => !x.IsDelete, include: x => x.Include(o => o.Product));
            return orderItems.Select(x => _mapper.Map<OrderItemGetDTO>(x)).ToList();
        }

        public async Task<IResult> CreateAsync(OrderItemCreateDTO dto)
        {
            var product = await _productRepository.GetAsync(p => p.Id == dto.ProductId);
            if (product == null)
            {
                return new ErrorResult("Product  not found.");
            }

            var orderItem = new OrderItem
            {
                ProductId = dto.ProductId,
                UnitPrice = dto.UnitPrice,
            };
            await _orderItemRepository.AddAsync(orderItem);
            return new SuccessResult("Order item successfully created");
        }

        public async Task<IDataResult<OrderItemGetDTO>> GetAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDelete);
            if (orderItem == null)
            {
                return new ErrorDataResult<OrderItemGetDTO>("Order item not found");
            }
            var dto = _mapper.Map<OrderItemGetDTO>(orderItem);
            return new SuccessDataResult<OrderItemGetDTO>(dto, "Order item retrieved successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDelete);
            if (orderItem == null)
            {
                return new ErrorResult("Order item not found");
            }
            orderItem.IsDelete = true;
            await _orderItemRepository.UpdateAsync(orderItem);
            return new SuccessResult("Order item removed");
        }

        public async Task<IResult> UpdateAsync(int id, OrderItemUpdateDTO dto)
        {
            var orderItem = await _orderItemRepository.GetAsync(x => x.Id == id && !x.IsDelete);
            if (orderItem == null)
            {
                return new ErrorResult("Order item not found");
            }
            _mapper.Map(dto, orderItem);
            await _orderItemRepository.UpdateAsync(orderItem);
            return new SuccessResult("Order item updated successfully");
        }
    }
}
