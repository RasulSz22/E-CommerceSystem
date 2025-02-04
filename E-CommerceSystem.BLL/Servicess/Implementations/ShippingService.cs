using AutoMapper;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.IShippingRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.DTOs.PaymentDTO;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.DTOs.ShippingDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Enum;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete;
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
    public class ShippingService : IShippingService
    {
        readonly IShippingRepository _shippingRepository;
        readonly IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(ShippingCreateDTO dto)
        {
            Shipping shipping = _mapper.Map<Shipping>(dto);
            await _shippingRepository.AddAsync(shipping);
            return new SuccessResult("Shipping Successfully Added");
        }

        public async Task<IDataResult<ShippingGetDTO>> GetAsync(int id)
        {
            var Shipping = _shippingRepository.GetAsync(x => !x.IsDelete && x.Id == id).Result;
            if (Shipping == null)
            {
                return new ErrorDataResult<ShippingGetDTO>("Shipping Not Found");
            }
            ShippingGetDTO dto = new ShippingGetDTO()
            {
                Id = Shipping.Id,
                Status = Shipping.Status,
            };
            return new SuccessDataResult<ShippingGetDTO>(dto, "Get Shipping");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Shipping shipping = await _shippingRepository.GetAsync(x => !x.IsDelete && x.Id == id);
            if (shipping == null)
            {
                return new ErrorResult("Shipping Not Found");
            }
            shipping.IsDelete = true;
            return new SuccessResult("Shipping Removed");
        }

        public async Task<IResult> UpdateAsync(int id, ShippingUpdateDTO dto)
        {
            Shipping shipping = await _shippingRepository.GetAsync(x => !x.IsDelete && x.Id == id, "Product");
            if (shipping == null)
            {
                return new ErrorResult("Shipping Not Found");
            }
            shipping.Status = dto.Status;
            await _shippingRepository.UpdateAsync(shipping);
            return new SuccessResult("Shipping Successfuly Updated");
        }
    }
}
