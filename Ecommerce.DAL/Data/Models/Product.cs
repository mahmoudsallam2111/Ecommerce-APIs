using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }

        [Required]
        public bool Available { get; set; }

        [Range(1 , 5 , ErrorMessage = "Rate must be between 1 and 5")]
        public int Rate { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
