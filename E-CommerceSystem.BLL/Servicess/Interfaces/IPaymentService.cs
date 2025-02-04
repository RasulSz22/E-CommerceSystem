using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.DTOs.PaymentDTO;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_CommerceSystem.BLL.Servicess.Interfaces
{
    public interface IPaymentService
    {
        public Task<IDataResult<List<PaymentGetDTO>>> GetAllAsync();
        public Task<IResult> CreateAsync(PaymentCreateDTO dto);
        public Task<IResult> RemoveAsync(int id);
        public Task<IResult> UpdateAsync(int id, PaymentUpdateDTO dto);
        public Task<IDataResult<PaymentGetDTO>> GetAsync(int id);
    }
}
