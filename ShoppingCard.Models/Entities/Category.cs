using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Models.Entities {
    public class Category:BaseEntity {
        public Category()
        {
                Products=new HashSet<Product>();
        }
    [Required(ErrorMessage ="اتنل املا الاسم ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="املا يلا ")]
        public int Order { get; set; }
      public virtual ICollection<Product> Products { get; set; }

    }
}
