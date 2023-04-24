using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
   public class WriteProductDto
    { 
        public required int ProductId { get; set; }
        public  required string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public required double  Price { get; set; }
        public required bool Available { get; set; }

        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5")]
        public required int Rate { get; set; }
        public  int CategoryId { get; set; } = 3;

    }
}
