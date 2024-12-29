using AutoMapper;
using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.ErrorResults;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.SuccessResults;
using Microsoft.Identity.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Implementations
{
    public class CategoryService : ICategoryService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private IRepository<Category> _categoryRepository;

        public CategoryService(IMapper mapper, IUnitOfWork unitofwork, IRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> CreateAsync(CategoryCreateDTO dto)
        {
            try
            {
                var category = _mapper.Map<Category>(dto);
                await _categoryRepository.AddAsync(category);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Category created successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while creating the category,Inner Exceptiom:{ex.InnerException}");
                return new ErrorResult("Failed to create category.");
            }
        }

        public Task<PagginatedResponse<CategoryGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryGetDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == id);
                if (category == null)
                {
                    return new ErrorResult("Category not found.");
                }
                await _categoryRepository.RemoveAsync(category);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while removing the category with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to delete category.");
            }
        }

        public async  Task<IResult> UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(s => s.Id == id);
                if (category == null)
                {
                    return new ErrorResult("Category not found.");
                }
                _mapper.Map(dto, category);
                await _categoryRepository.UpdateAsync(category);
                await _unitofwork.SaveChangesAsync();
                return new SuccessResult("Category updated successfully.");
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while updating the category with ID {id}: {ex.Message}");
                return new ErrorResult("Failed to update category.");
            }
        }
    }
}
