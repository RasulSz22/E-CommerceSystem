using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceSystemContex context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ECommerceSystemContex _context)
        {
            context = _context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                //return _repositories[typeof(TEntity)] as IRepository<TEntity>;
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            IRepository<TEntity> repository = new Repository<TEntity>(context /*as AppDbContext*/);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}

