using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Categorys { get ; set ; }
        public IProductRepository Producds { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categorys = new CategoryRepository(context);
            Producds = new ProductRepository(context);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {

            _context.SaveChanges();
        }
    }
}
