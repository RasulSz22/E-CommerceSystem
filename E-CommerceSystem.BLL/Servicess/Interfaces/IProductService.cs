﻿using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface IProductService
    {
        public Task<PagginatedResponse<ProductGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6);
        public Task<IResult> CreateAsync(ProductCreateDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, ProductUpdateDTO dto);
        public Task<IDataResult<ProductGetDTO>> GetAsync(int id);  //test 
    }
}