using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
   public class ReadwishlistwithItemsDto
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string userID { get; set; } = string.Empty;
        public ICollection<ReadWishItemDto> wishItems { get; set; } = new HashSet<ReadWishItemDto>();
    }
}
