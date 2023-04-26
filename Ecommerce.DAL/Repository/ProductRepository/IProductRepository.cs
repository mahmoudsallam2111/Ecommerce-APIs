using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
   public interface IProductRepository:IGenericRepository<Product>
    {
        Task<Product?> SearchProductByName(string Name);
       Task<List<Product>>  SearchProductByCategory(int id);
        Task<List<Product>> FilterProductByPrices(double Min , double Max);
        Task<List<Product>> GetProductPaginated(int PageNumber , int PageSize);
       Task<IEnumerable<Product>> FilterProductByRate(int rate);
        Task<IEnumerable<Product>> FilterProductByAvailability(bool ava); 


    }
}
