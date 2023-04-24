using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DA
{
    public class DeliveryMethod
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DeliveryTime { get; set; } = string.Empty;
        public string Description{ get; set; } = string.Empty;
        public Decimal Price { get; set; } = 0;
    }
}
