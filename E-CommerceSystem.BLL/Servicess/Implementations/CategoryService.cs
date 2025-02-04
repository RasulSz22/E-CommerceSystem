using AutoMapper;
using E_CommerceSystem.BLL.Extentions;
using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Abstract.ICategoryRepository;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.DTOs.OrderItemDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.ErrorResults;
using E_CommerceSystem.Entities.Utilities.Results.Concrete.SuccessResults;
using Microsoft.EntityFrameworkCore;
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
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> CreateAsync(CategoryCreateDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                return new ErrorResult("Category name is required!");
            }

            if (dto.ParentId != null)
            {
                var parentCategory = await _categoryRepository.GetAsync(x => x.Id == dto.ParentId);
                var subCategory = _mapper.Map<Category>(dto);
                subCategory.ParentId = parentCategory.Id;
                parentCategory.Children.Add(subCategory);
                await _categoryRepository.UpdateAsync(parentCategory);
            }
            else
            {
                var category = _mapper.Map<Category>(dto);
                category.ParentId = dto.ParentId;
                await _categoryRepository.AddAsync(category);
            }
            return new SuccessResult("Category Successfully Created");
        }



        public async Task<IDataResult<CategoryGetDTO>> GetAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => !x.IsDelete && x.Id == id);

            if (category == null)
            {
                return new ErrorDataResult<CategoryGetDTO>("Category not found");
            }

            CategoryGetDTO getCategoryDTO = new CategoryGetDTO
            {
                Name = category.Name,
                ParentId = category.ParentId,
                Id = category.Id
            };
            return new SuccessDataResult<CategoryGetDTO>(getCategoryDTO, "Get Category Successfully");
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => !x.IsDelete && x.Id == id);

            if (category == null)
            {
                return new ErrorResult("Category Not Found");
            }
            category.IsDelete = true;
            await _categoryRepository.UpdateAsync(category);
            return new SuccessResult("Category Removed Successfully");
        }

        public async Task<IResult> UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            var categoryToUpdate = await _categoryRepository.GetAsync(x => x.Id == id);
            if (categoryToUpdate == null)
            {
                return new ErrorResult("Category Not Foud");
            }

            categoryToUpdate.Name = dto.Name;
            categoryToUpdate.ParentId = dto.ParentId;

            if (dto.ParentId != null)
            {
                categoryToUpdate.ParentId = dto.ParentId;
                var parentCategory = await _categoryRepository.GetAsync(x => x.ParentId == dto.ParentId);
                if (parentCategory != null)
                {
                    parentCategory.Children.Clear();
                    parentCategory.Children.Add(categoryToUpdate);
                    await _categoryRepository.UpdateAsync(parentCategory);
                    await _categoryRepository.UpdateAsync(categoryToUpdate);
                }
            }
            await _categoryRepository.UpdateAsync(categoryToUpdate);
            return new SuccessResult("Category Successfully Updated");
        }


    }
}
