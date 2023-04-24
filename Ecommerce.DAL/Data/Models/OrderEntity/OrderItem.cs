using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
   public class OrderItem
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Quentity { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
       
    }
}
