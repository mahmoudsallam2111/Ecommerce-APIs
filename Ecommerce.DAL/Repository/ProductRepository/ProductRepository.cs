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

        public  Product? SearchProductByName(string Name)
        {

            return  context.Set<Product>().FirstOrDefault(p => p.Name == Name);

        }
        public  List<Product> SearchProductByCategory(int id)
        {
            return   context.Set<Product>().Where(c => c.CategoryId == id).ToList();

        }

        public List<Product> FilterProductByPrices(double Min, double Max)
        {
           return context.Set<Product>().Where(p=> p.Price < Max && p.Price >= Min).ToList();
        }

        public List<Product> GetProductPaginated(int PageNumber, int PageSize)
        {
           int productToSkip = (PageNumber- 1) * PageSize;
            return context.Set<Product>().OrderBy(p=>p.Id).Skip(productToSkip).Take(PageSize).ToList();
        }

        public IEnumerable<Product> FilterProductByRate(int rate)
        {
            return context.Set<Product>().Where(p => p.Rate == rate).ToList();
        }

        public IEnumerable<Product> FilterProductByAvailability(bool ava)
        {
            return context.Set<Product>().Where(p =>p.Available==ava).ToList();
        }
    }
}
