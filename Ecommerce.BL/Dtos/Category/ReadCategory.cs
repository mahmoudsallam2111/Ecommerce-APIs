using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class ReadCategory
    {
        
        public required string Name { get; set; } = string.Empty;
        public required int Id { get; set; }
    }
}
