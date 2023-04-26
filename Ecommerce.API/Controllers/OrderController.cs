using Ecommerce.BL;
using Ecommerce.DA;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        [HttpPost]
        [Route("CreateOrder")]
        [Authorize]
        public async Task CreateOrder(CreateOrderdto createOrderdto)
        {
           await orderManager.createOrder(createOrderdto);
        }


        [HttpGet]
        [Route("{id}")]
        public  ActionResult<ReadorderDto> GetById(int id)
        {
          return  orderManager.GetOrderById(id);
        }

        [HttpPost]
        [Route("GetOrderByUSerEmail")]
        public async Task<ActionResult<ReadorderDto> > GetOrderByUSerEmail(string EmailAddress)
        {
             var order =  await orderManager.GetOrderForUser(EmailAddress);

            if (order == null)
            {
                return BadRequest();
            }

            return order; 
        }


    }
}
