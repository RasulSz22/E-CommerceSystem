using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.OrderDTO
{
    public class OrderCreateDTO
    {
        public DateTime CreatedTime { get; set; }   
        public string OrderNotes { get; set; }
        public double TotalAmount { get; set; }
        public int Discount { get; set; }
        public string TrackingNumber { get; set; }
        public int PaymentId { get; set; }
        public int ShippingId { get; set; }
    }
}
