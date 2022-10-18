using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Models.Entities {
    public class Product:BaseEntity {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
       [Column(TypeName ="decimal(18,0)")]
        public double Price { get; set; }
        public string?  ImgUrl { get; set; }
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
