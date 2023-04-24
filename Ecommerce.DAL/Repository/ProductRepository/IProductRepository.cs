using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
   public interface IProductRepository:IGenericRepository<Product>
    {
        Product? SearchProductByName(string Name);
        List<Product>  SearchProductByCategory(int id);
        List<Product> FilterProductByPrices(double Min , double Max);
        List<Product> GetProductPaginated(int PageNumber , int PageSize);
        IEnumerable<Product> FilterProductByRate(int rate);
        IEnumerable<Product> FilterProductByAvailability(bool ava); 


    }
}
