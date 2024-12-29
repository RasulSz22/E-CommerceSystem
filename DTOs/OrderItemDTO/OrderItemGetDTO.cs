using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.OrderItemDTO
{
    public class OrderItemGetDTO
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
