using BooksWPF.Data;
using BooksWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Repository
{
    public class EFGenericRepository<TModel> : IGenericRepository<TModel> where TModel : BaseModel
    {

        DbContext _context;
        DbSet<TModel> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
        }

        public void Create(TModel item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public TModel FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TModel> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(TModel item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TModel> GetWithInclude(Func<TModel, bool> predicate,
            params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TModel> Include(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Update(TModel item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
