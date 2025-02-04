using E_CommerceSystem.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.ShippingDTO
{
    public class ShippingUpdateDTO
    {
        public int Id { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
    }
}
