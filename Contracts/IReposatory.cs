using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReposatory<T> where T:class
    {
        IQueryable<T> Query();
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T GetById(params object[] id);
        Task<T> GetByIdAsync(params object[] id);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T updated);
        Task<T> UpdateAsync(T updated);
        void Delete(T t);
        Task<int> DeleteAsync(T t);
        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? page = null,
            int? pageSize = null);
        T FindBy(Expression<Func<T, bool>> predicate);
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate);
        bool Exist(Expression<Func<T, bool>> predicate);
    }
}
