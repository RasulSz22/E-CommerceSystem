using E_CommerceSystem.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.ShippingDTO
{
    public class ShippingCreateDTO
    {
        public int OrderId { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
    }
}
