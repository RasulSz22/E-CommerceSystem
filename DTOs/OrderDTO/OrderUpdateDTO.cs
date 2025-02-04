using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.OrderDTO
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public int PaymentId { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
}
