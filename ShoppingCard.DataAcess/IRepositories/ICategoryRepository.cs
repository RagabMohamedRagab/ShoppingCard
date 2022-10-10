using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.IRepositories {
    public interface ICategoryRepository:IRepository<Category> {
        public void Update(Category category);
    }
}
