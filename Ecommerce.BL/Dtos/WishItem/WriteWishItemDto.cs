using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.B
{
    public class WriteWishItemDto
    {
        public required int prodId { get; set; }
        public required int whishlstID { get; set; }
        public required DateTime AddedDate { get; set; }
    }
}
