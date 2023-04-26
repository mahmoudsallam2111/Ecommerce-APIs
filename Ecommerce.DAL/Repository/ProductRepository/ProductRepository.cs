using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.DAL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly EcommerceDB context;

        public ProductRepository(EcommerceDB Context) : base(Context)
        {
            context = Context;
        }

        public   async Task<Product?> SearchProductByName(string Name)
        {
            return await  context.Set<Product>().FirstOrDefaultAsync(p => p.Name == Name);  
        }

        public  async Task<List<Product>> SearchProductByCategory(int id)
        {
            return  await context.Set<Product>().Where(c => c.CategoryId == id).ToListAsync();

        }

        public async Task<List<Product>> FilterProductByPrices(double Min, double Max)
        {
            return await context.Set<Product>().Where(p => p.Price < Max && p.Price >= Min).ToListAsync();
        }

        public async Task< List<Product>> GetProductPaginated(int PageNumber, int PageSize)
        {
           int productToSkip = (PageNumber- 1) * PageSize;
            return await context.Set<Product>().OrderBy(p => p.Id).Skip(productToSkip).Take(PageSize).ToListAsync();
        }

        public async Task< IEnumerable<Product>> FilterProductByRate(int rate)
        {
            return await context.Set<Product>().Where(p => p.Rate == rate).ToListAsync();
        }

        public async Task< IEnumerable<Product>> FilterProductByAvailability(bool ava)
        {
            return await context.Set<Product>().Where(p => p.Available == ava).ToListAsync();
        }

        
    }
}
