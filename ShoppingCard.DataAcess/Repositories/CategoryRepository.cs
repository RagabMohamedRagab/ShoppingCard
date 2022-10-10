using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class CategoryRepository : Repository<Category>, ICategoryRepository {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var cat = _context.Set<Category>().Find(category.Id);
            if(cat != null)
            {
                cat.Name= category.Name;
                cat.UpdateOn = DateTime.Now;
            }
        }
    }
}
