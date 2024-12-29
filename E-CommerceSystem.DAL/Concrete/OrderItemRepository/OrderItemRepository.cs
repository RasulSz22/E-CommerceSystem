using E_CommerceSystem.DAL.Abstract.IOrderItemRepository;
using E_CommerceSystem.DAL.Abstract.IOrderRepository;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Concrete.OrderItemRepository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ECommerceSystemContex context) : base(context)
        {
        }
    }
}
