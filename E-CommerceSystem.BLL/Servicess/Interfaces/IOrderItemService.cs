using E_CommerceSystem.BLL.Model;
using E_CommerceSystem.DTOs.OrderItemDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface IOrderItemService
    {
        public Task<List<OrderItemGetDTO>> GetAllAsync();
        public Task<IResult> CreateAsync(OrderItemCreateDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, OrderItemUpdateDTO dto);
        public Task<IDataResult<OrderItemGetDTO>> GetAsync(int id);

        //public Task<PagginatedResponse<OrderItemGetDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 6);
        //public Task<IResult> CreateAsync(OrderItemCreateDTO dto);
        //public Task<IResult> RemoveAsync(int id);
        //public Task<IResult> UpdateAsync(int id, OrderItemUpdateDTO dto);
        //public Task<IDataResult<OrderItemGetDTO>> GetAsync(int id);
    }
}
