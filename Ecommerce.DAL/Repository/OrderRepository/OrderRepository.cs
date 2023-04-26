using Ecommerce.DA;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly EcommerceDB context;
        private readonly IProductRepository productRepository;
        private readonly IBasketRepository basketRepository;
        private readonly UserManager<User> userManager;

        public OrderRepository(EcommerceDB Context, IProductRepository productRepository, IBasketRepository basketRepository, UserManager<User> userManager) : base(Context)
        {
            context = Context;
            this.productRepository = productRepository;
            this.basketRepository = basketRepository;
            this.userManager = userManager;
        }
        public async Task createOrder(string EmailAddress, DeliveryMethod deliveryMethod, string basketId, string ShippingAddress)
        {
            var items = new List<OrderItem>();
            var basket = await basketRepository.GetBasketAsync(basketId);
            foreach (var item in basket.basketItems)
            {
                var productitem = productRepository.GetByID(item.Id);
                var Orderitem = new OrderItem
                {
                    ProductId = item.Id,
                    Price =(double) item.Price,
                    Quentity = item.Quentity,
                };
                items.Add(Orderitem);
            }

            var subtoatal = (decimal)items.Sum(a => a.Price * a.Quentity);

            var user = await userManager.FindByEmailAsync(EmailAddress);
            var user_id = user.Id;

            var order = new Order
            {
                OrderItems = items,
                CreatedDate = DateTime.Now,
                ShippingToAddress = ShippingAddress,
                DeliveryMethod = deliveryMethod,
                SubTotal = subtoatal,
                UserId = user_id
            };

            context.Orders.Add(order);
            context.SaveChanges();

        }

     
        public async Task<Order?> GetOrderForUser(string UserEmailAddress)
        {
            var user = await userManager.FindByEmailAsync(UserEmailAddress);
            
            var userId = user.Id;
            // if u want to use find the id must be of type int
            return context.Set<Order>().FirstOrDefault(a => a.UserId == userId);
           
        }
    }
}
