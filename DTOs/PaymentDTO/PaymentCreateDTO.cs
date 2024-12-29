using E_CommerceSystem.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.PaymentDTO
{
    public class PaymentCreateDTO
    {
        public PaymentMethods PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
