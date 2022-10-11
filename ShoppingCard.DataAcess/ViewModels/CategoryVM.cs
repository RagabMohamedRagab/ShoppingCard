using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.DataAcess.ViewModels {
    public class CategoryVM {
        public CategoryVM()
        {
            category=new Category();
            categories=new List<Category>();
        }
        public Category category { get; set; }
        public IEnumerable<Category> categories { get; set; }   
    }
}
