using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.ViewModels {
    public class ProductVM {
        public ProductVM()
        {
            product = new Product();
            Products=new List<Product>();
        }
        public Product product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
