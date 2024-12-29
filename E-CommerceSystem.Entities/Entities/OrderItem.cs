using E_CommerceSystem.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Entities
{
    public class OrderItem :BaseEntity
    {
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice => Price * Quantity;
        public  int OrderId { get; set; }
        public   Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
