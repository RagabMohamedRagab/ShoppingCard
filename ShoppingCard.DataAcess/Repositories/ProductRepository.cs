using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class ProductRepository : Repository<Product>, IProductRepository {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var Pro = _context.Products.Find(product.Id);
            if(Pro != null)
            {
                Pro.Name = product.Name;
                Pro.Description = product.Description;
                Pro.Price = product.Price;
                if (product.ImgUrl != null)
                {
                    Pro.ImgUrl = $"\\Images\\{product.ImgUrl}";
                }
                Pro.CategoryId=product.CategoryId;
                Pro.UpdateOn=DateTime.Now;
            }
        }
    }
}




