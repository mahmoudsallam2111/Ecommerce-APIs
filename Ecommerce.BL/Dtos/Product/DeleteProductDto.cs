using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class DeleteProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
