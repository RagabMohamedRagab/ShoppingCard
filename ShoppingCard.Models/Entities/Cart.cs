using ShoppingCard.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Models.Entities {
    public class Cart:BaseEntity {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public int Count { get; set; }
    }
}
