using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface IOrderService
    {
        public Task<IResult> CreateAsync(OrderCreateDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, OrderUpdateDTO dto);
        public Task<IDataResult<OrderGetDTO>> GetAsync(int id);
    }
}
