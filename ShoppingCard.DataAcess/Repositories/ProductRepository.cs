using ShoppingCard.DataAcess.DbContext;
using ShoppingCard.DataAcess.IRepositories;
using ShoppingCard.Models.Entities;
using ShoppingCard.Utility.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.Repositories {
    public class ProductRepository : Repository<Product>, IProductRepository {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        public ProductRepository(ApplicationDbContext context, IFileService fileService) : base(context)
        {
            _context = context;
            _fileService = fileService;
        }

        public void Update(Product product)
        {
            var Pro = _context.Products.Find(product.Id);
            if(Pro != null)
            {
                Pro.Name = product.Name;
                Pro.Description = product.Description;
                Pro.Price = product.Price;
                if (product.file != null)
                {
                    _fileService.DeleImg(Pro.ImgUrl);
                    Pro.ImgUrl = product.file.FileName;
                }
                Pro.CategoryId=product.CategoryId;
                Pro.UpdateOn=DateTime.Now;
            }
        }
    }
}




