using Ecommerce.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task createOrder(string EmailAddress, DeliveryMethod deliveryMethod, string basketId, string ShippingAddress);
        Task<Order?> GetOrderForUser(string UserEmailAddress);

    }
}
