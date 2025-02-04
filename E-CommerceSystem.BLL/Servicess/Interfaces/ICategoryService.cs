using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface ICategoryService
    {
       // public Task<PagginatedResponse<CategoryGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6);
        public Task<IResult> CreateAsync(CategoryCreateDTO dto);
        public Task<IResult> UpdateAsync(int id, CategoryUpdateDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IDataResult<CategoryGetDTO>> GetAsync(int id);
    }
}
