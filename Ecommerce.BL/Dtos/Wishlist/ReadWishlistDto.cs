using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class ReadWishlistDto
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string userID { get; set; } = string.Empty;
    }
}
