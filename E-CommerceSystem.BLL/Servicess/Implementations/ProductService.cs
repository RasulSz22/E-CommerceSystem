using AutoMapper;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.ProductDTO;
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
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<Product> _productRepository;

        public ProductService(IMapper mapper, IUnitOfWork unitofwork, IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _productRepository = productRepository;
        }

        public async Task<IResult> CreateAsync(ProductCreateDTO dto)
        {
            try
            {
                var product = _mapper.Map<Product>(dto);
                await _productRepository.AddAsync(product);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Product created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the product,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create product.");
            }
        }

        public Task<IDataResult<ProductGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetAsync(c => c.Id == id);
                if (product == null)
                {
                    return new ErrorResult("Product not found.");
                }
                await _productRepository.RemoveAsync(product);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the product with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete product.");
            }
        }

        public async Task<IResult> UpdateAsync(int id, ProductUpdateDTO dto)
        {
            try
            {
                var product = await _productRepository.GetAsync(s => s.Id == id);
                if (product == null)
                {
                    return new ErrorResult("Product not found.");
                }
                _mapper.Map(dto, product);
                await _productRepository.UpdateAsync(product);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Product updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the product with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update product.");
            }
        }
    }
}
