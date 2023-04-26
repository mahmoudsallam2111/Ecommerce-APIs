using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
   //public record ReadproductDto(string Name , int price);

    public class ReadproductDto
    {
        public  required string Name { get; set; } = string.Empty;
        public  required double Price { get; set; } 

        public  required bool Available { get; set; } 
        public  required int Rate { get; set; } 

    }
}
