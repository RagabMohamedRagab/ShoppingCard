using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.IRepositories {
    public interface IUnitOfWork:IDisposable {
        public ICategoryRepository Categorys{ get; set; }
        public IProductRepository Producds { get;  set; }
        public void Save();
    }
}
