using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class WishItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int prodID { get; set; }

        [ForeignKey("WishList")]
        public int whishlstID { get; set; }
        public DateTime AddedDate  { get; set; }

      

        public Product? Product{ get; set; }
        public WishList? WishList { get; set; }
    }
}
