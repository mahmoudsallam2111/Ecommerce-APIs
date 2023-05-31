using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class WriteWishlistDto
    {
        //public required int ID { get; set; }
        public required DateTime CreatedDate { get; set; }

        public required string userID { get; set; }
    }
}
