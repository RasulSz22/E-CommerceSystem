using E_CommerceSystem.DAL.Abstract.ICategoryRepository;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Concrete.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceSystemContex context) : base(context)
        {
        }
    }
}
