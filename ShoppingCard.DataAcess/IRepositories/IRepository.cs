using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.IRepositories {
    public  interface IRepository<T> where T:class {
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Predicate, string Includes = null);
        public T Get(Expression<Func<T, bool>> Predicate, string Includes = null);
        public void Add(T t);
        public void AddRange(IEnumerable<T> t);
        public void Delete(T t);
        public void DeleteRange(IEnumerable<T> t);
    }
}
