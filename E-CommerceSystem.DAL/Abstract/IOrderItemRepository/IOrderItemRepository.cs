using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Abstract.IOrderItemRepository
{
    public interface IOrderItemRepository:IRepository<OrderItem>
    {
    }
}
