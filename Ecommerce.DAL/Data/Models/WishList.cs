using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class WishList
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public string userID { get; set; } = string.Empty;

        public User? User{ get; set; }
        public ICollection<WishItem> wishItems { get; set; } = new HashSet<WishItem>();
    }
}
