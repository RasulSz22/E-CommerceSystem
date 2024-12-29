using E_CommerceSystem.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public  int CategoryId { get; set; } 
        public  Category Category { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        //public Product Parent { get; set; }
        //public Category PCategory { get; set; }
    }
}
