using AutoMapper;
using Ecommerce.DA;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{

    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderManager(IOrderRepository orderRepository , IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task createOrder(CreateOrderdto createOrderdto)
        {
          await  orderRepository.createOrder( createOrderdto.EmailAddress , createOrderdto.DeliveryMethod ,createOrderdto.basketId, createOrderdto.ShippingToAddress);
        }


       public async Task<ReadorderDto> GetOrderById(int id)
        {
            var orderfromDb = await orderRepository.GetByID(id);
            if (orderfromDb == null)
            {
                return new ReadorderDto { 
                address = "",
                TotalPrice = 0,

                };
            }

            var readorder = new ReadorderDto();
            readorder.address = orderfromDb.ShippingToAddress;
            readorder.createdate = orderfromDb.CreatedDate;
            readorder.TotalPrice = orderfromDb.SubTotal;

            return readorder;
        }


        public async Task<ReadorderDto?> GetOrderForUser(string EmailAddress)
        {
            var OrderFromDb = await orderRepository.GetOrderForUser(EmailAddress);

            var readorder = new ReadorderDto();

            readorder.address = OrderFromDb.ShippingToAddress;
            readorder.createdate = OrderFromDb.CreatedDate;
            readorder.TotalPrice = OrderFromDb.SubTotal;

            return readorder;

        }
    }
}
