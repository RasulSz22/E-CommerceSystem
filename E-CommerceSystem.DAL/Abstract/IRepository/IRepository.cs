using E_CommerceSystem.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Abstract.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes);
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression);
        public Task RemoveAsync(T entity);
        public Task<int> SaveChangesAsync();
        Task<List<T>> GetListAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IQueryable<T>> include = null
             );
        //public Task AddAsync(T entity);
        //public Task UpdateAsync(T entity);
        //public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] Includes);
        //public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression);
        //public Task RemoveAsync(T entity);
        //Task<List<T>> GetAllAsync();
        //Task<int> CountAsync();
        //public Task<int> SaveChangesAsync();
    }
}
