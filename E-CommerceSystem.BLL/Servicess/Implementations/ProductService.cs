using AutoMapper;
using E_CommerceSystem.BLL.Extentions;
using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IProductRepository;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.ErrorResults;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.SuccessResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
        private readonly IWebHostEnvironment _env;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IWebHostEnvironment env, IProductRepository productRepository, IMapper mapper)
        {
            _env = env;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
            return new SuccessResult("Product successfully created");
        }

        public async Task<PagginatedResponse<ProductGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            var query = _productRepository.GetQuery(x => !x.IsDelete)
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Category);
            var totalCount = await query.CountAsync();
            var paginatedProducts = await query.ToPagedListAsync(pageNumber, pageSize);

            var productDtos = paginatedProducts.Datas.Select(x => _mapper.Map<ProductGetDTO>(x)).ToList();
            return new PagginatedResponse<ProductGetDTO>(
                productDtos, paginatedProducts.PageNumber, paginatedProducts.PageSize, totalCount);
        }

        public async Task<IDataResult<ProductGetDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDelete && x.Id == id);
            if (product == null)
            {
                return new ErrorDataResult<ProductGetDTO>("Product not found");
            }

            var dto = _mapper.Map<ProductGetDTO>(product);
            return new SuccessDataResult<ProductGetDTO>(dto, "Product retrieved successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDelete && x.Id == id);
            if (product == null)
            {
                return new ErrorResult("Product not found");
            }

            product.IsDelete = true;
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product removed");
        }

        public async Task<IResult> UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var product = await _productRepository.GetAsync(x => !x.IsDelete && x.Id == id);
            if (product == null)
            {
                return new ErrorResult("Product not found");
            }

            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);
            return new SuccessResult("Product updated successfully");
        }
    }
}
