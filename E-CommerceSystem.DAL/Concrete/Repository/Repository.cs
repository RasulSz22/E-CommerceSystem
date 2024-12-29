using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_CommerceSystem.DAL.Concrete.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly ECommerceSystemContex _context;
        public Repository(ECommerceSystemContex context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
            var result=await Table.AddAsync(data);
            return result.State == EntityState.Added;
        }

        public IQueryable<T> GetAll()
        {
            var query=Table.AsQueryable();
            return query;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T data)
        {
            var delete = Table.Remove(data);
            return delete.State == EntityState.Deleted;
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveById(int id)
        {
            var delete = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(delete);
        }

        public bool UpdateAsync(T data)
        {
            var update = Table.Update(data);
            return update.State == EntityState.Modified;
        }

        Task IRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        //public async Task AddAsync(T entity)
        //{
        //    await _context.AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}
        //public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes)
        //{
        //    var query = _context.Set<T>().Where(expression);
        //    if (Includes != null)
        //    {
        //        foreach (string includes in Includes)
        //        {
        //            query = query.Include(includes);
        //        }
        //    }
        //    return await query.FirstOrDefaultAsync();
        //}

        //public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        //{
        //    return _context.Set<T>().Where(expression);
        //}

        //public async Task RemoveAsync(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //    await _context.SaveChangesAsync();
        //}
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
 }
