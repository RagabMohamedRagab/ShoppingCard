using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Utility.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        public ICategoryRepository Categorys { get ; set ; }
        public IProductRepository Producds { get; set; }
        public UnitOfWork(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService=fileService;
            Categorys = new CategoryRepository(context);
            Producds = new ProductRepository(context,fileService);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {

          return  _context.SaveChanges();
        }
    }
}
