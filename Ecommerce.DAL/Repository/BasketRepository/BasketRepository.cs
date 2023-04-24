using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IDatabase = StackExchange.Redis.IDatabase;

namespace Ecommerce.DAL
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;   // interface called Idatabase inside the redis
        private readonly ILogger<BasketRepository> logger;

        public BasketRepository(IConnectionMultiplexer Redis , ILogger<BasketRepository> logger)
        {
           _database =  Redis.GetDatabase();
            this.logger = logger;
        }

        public async Task<CustomerBasket> GetBasketAsync(string Id)
        {
            var data = await _database.StringGetAsync(Id);
            logger.LogInformation(data);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<bool> DeleteBasketAsync(string Id)
        {
            return await _database.KeyDeleteAsync(Id);   
        }

     
        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var created = await _database.StringSetAsync(customerBasket.Id , JsonSerializer.Serialize(customerBasket), TimeSpan.FromDays(30));

            if (!created)
            {
                return null;
            }
            return await GetBasketAsync(customerBasket.Id);
        }

    }
}
