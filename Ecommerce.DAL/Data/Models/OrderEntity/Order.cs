using Ecommerce.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ShippingToAddress { get; set; } = string.Empty;
        public DeliveryMethod? DeliveryMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal SubTotal { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }

    }
}
