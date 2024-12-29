using AutoMapper;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.ShippingDTO;
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
    public class ShippingService : IShippingService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<Shipping> _shippingRepository;
        public ShippingService(IMapper mapper, IUnitOfWork unitofwork, IRepository<Shipping> shippingRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _shippingRepository = shippingRepository;
        }

        public async Task<IResult> CreateAsync(ShippingCreateDTO dto)
        {
            try
            {
                var shipping = _mapper.Map<Shipping>(dto);
                await _shippingRepository.AddAsync(shipping);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Shipping created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the shipping,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create shipping.");
            }
        }

        public Task<IDataResult<ShippingGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var shipping = await _shippingRepository.GetAsync(c => c.Id == id);
                if (shipping == null)
                {
                    return new ErrorResult("Shipping not found.");
                }
                await _shippingRepository.RemoveAsync(shipping);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Shipping deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the shipping with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete shipping.");
            }
        }

        public async Task<IResult> UpdateAsync(int id, ShippingUpdateDTO dto)
        {
            try
            {
                var shipping = await _shippingRepository.GetAsync(s => s.Id == id);
                if (shipping == null)
                {
                    return new ErrorResult("Shipping not found.");
                }
                _mapper.Map(dto, shipping);
                await _shippingRepository.UpdateAsync(shipping);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Shipping updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the shipping with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update shipping.");
            }
        }
    }
}
