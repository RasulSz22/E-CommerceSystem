using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.OrderDTO
{
    public class OrderGetDTO
    {
        public int ID { get; set; }
        public string AppUserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public List<int> OrderItemIds { get; set; }
        public int PaymentId { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public OrderGetDTO()
        {
            OrderItemIds = new List<int>();
        }
    }
}
