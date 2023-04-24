using Ecommerce.DA;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class CreateOrderdto
    {
        public required DeliveryMethod? DeliveryMethod { get; set; }
        public required string ShippingToAddress { get; set; } = string.Empty;

        public required string basketId { get; set; } = string.Empty;
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;

        [EmailAddress]
        public required string EmailAddress { get; set;} = string.Empty;
    }
}
