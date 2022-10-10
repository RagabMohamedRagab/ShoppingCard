using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.IRepositories {
    public interface IProductRepository:IRepository<Product> {
        public void Update(Product product);
    }
}
