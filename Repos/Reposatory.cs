using Contracts;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repos
{
    public abstract class Reposatory<T>:IReposatory<T> where T:class
    {
        private readonly MyContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public Reposatory(MyContext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public  IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public  ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public  async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public  T GetById(params object[] id)
        {
            return _context.Set<T>().Find(id);
        }

        public  async Task<T> GetByIdAsync(params object[] id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public  ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public  async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public  T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public  async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public  T Update(T updated)
        {
            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _context.SaveChanges();

            return updated;
        }

        public  async Task<T> UpdateAsync(T updated)
        {
            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            await _unitOfWork.CommitAsync();

            return updated;
        }

        public  void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public  async Task<int> DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            return await _unitOfWork.CommitAsync();
        }

        public  IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (
                    var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query.ToList();
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }

        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync<T>(predicate);
        }

        public  bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _context.Set<T>().Where(predicate);
            return exist.Any() ? true : false;
        }

    }
}
