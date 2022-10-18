using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Models.Entities {
    public class BaseEntity {
        public BaseEntity()
        {
            CreateOn=DateTime.Now;
  
        }
        public int Id { get; set; }
       public DateTime CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
     
    }
}
