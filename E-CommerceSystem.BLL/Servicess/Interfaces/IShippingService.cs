using E_CommerceSystem.DTOs.ShippingDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface IShippingService
    {
        public Task<IResult> CreateAsync(ShippingCreateDTO dto);

        public Task<IResult> RemoveAsync(int id);

        public Task<IResult> UpdateAsync(int id, ShippingUpdateDTO dto);
        public Task<IDataResult<ShippingGetDTO>> GetAsync(int id);
    }
}
