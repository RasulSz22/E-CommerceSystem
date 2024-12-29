using E_CommerceSystem.DAL.Abstract.IProductRepository;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Concrete.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceSystemContex context) : base(context)
        {
        }
    }
}
