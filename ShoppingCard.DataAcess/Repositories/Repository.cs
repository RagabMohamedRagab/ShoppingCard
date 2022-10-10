using Microsoft.EntityFrameworkCore;
using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class Repository<T> : IRepository<T> where T : class {
        private readonly ApplicationDbContext _context;
        private DbSet<T> db;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            db=_context.Set<T>();
        }

        public void Add(T t)
        {
            db.Add(t);
        }

        public void AddRange(IEnumerable<T> t)
        {
            db.AddRange(t);
        }

        public void Delete(T t)
        {
            db.Remove(t);
        }

        public void DeleteRange(IEnumerable<T> t)
        {
            db.RemoveRange(t);
        }

        public T Get(Expression<Func<T, bool>> predicate, string Includes = null)
        {
            IQueryable<T> query = db;
            query = query.Where(predicate);
            if (Includes != null)
            {
                foreach (var item in Includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string Includes = null)
        {
            IQueryable<T> query = db;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (Includes != null)
            {
                foreach (var item in Includes.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }
}
