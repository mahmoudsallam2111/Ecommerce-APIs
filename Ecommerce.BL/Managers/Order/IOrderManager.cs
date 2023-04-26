using Ecommerce.DA;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public interface IOrderManager
    {
        Task createOrder(CreateOrderdto createOrderdto);
       Task< ReadorderDto >GetOrderById(int id);
       Task<ReadorderDto?> GetOrderForUser(string EmailAddress); 
    }
}
