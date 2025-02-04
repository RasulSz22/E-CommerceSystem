using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_CommerceSystem.DAL.Concrete.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceSystemContex _context;

        public Repository(ECommerceSystemContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var query = _context.Set<T>().Where(expression);
            if (includes?.Any() == true)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            return _context.Set<T>().Where(expression);
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }
        //readonly ECommerceSystemContex _context;
        //public Repository(ECommerceSystemContex context)
        //{
        //    _context = context;
        //}

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

        //public async  Task<List<T>> GetAllAsync()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public async Task<int> CountAsync()
        //{
        //    return await _context.Set<T>().CountAsync();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}

        //public DbSet<T> Table => _context.Set<T>();

        //public async Task<bool> AddAsync(T entity)
        //{
        //    var result=await Table.AddAsync(entity);
        //    return result.State == EntityState.Added;
        //}

        //public IQueryable<T> GetAll()
        //{
        //    var query=Table.AsQueryable();
        //    return query;
        //}

        //public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    var data = await Table.FirstOrDefaultAsync(x => x.Id == id);
        //    return data;
        //}

        //public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Remove(T data)
        //{
        //    var delete = Table.Remove(data);
        //    return delete.State == EntityState.Deleted;
        //}

        //public Task RemoveAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> RemoveById(int id)
        //{
        //    var delete = await Table.FirstOrDefaultAsync(x => x.Id == id);
        //    return Remove(delete);
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    var update = Table.Update(entity);
        //    return update.State == EntityState.Modified;
        //}


    }
}
