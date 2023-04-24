using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
   public class CustomerBasket
    {
        public string Id { get; set; } = string.Empty;
        public ICollection<BasketItem> basketItems { get; set; } = new HashSet<BasketItem>();  
    }
}
