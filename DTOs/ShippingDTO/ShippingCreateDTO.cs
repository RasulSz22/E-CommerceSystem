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
        public string ShippingAddress { get; set; }
        public ShippingStatus Status { get; set; }
        public string TrackingNumber { get; set; }
        public int OrderId { get; set; }
    }
}
