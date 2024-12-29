using E_CommerceSystem.DAL.Abstract.IShippingRepository;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Concrete.ShippingRepository
{
    public class ShippingRepository : Repository<Shipping>, IShippingRepository
    {
        public ShippingRepository(ECommerceSystemContex context) : base(context)
        {
        }
    }
}
