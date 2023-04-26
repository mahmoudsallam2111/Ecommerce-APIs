using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public interface IProductManager
    {
      Task<  IEnumerable<ReadproductDto> >GetAll();
       Task< ReadproductDto> GetProductById(int id);
      Task< ReadproductDto> AddProduct(WriteProductDto writeProductDto);
      Task< ReadproductDto> RemoveProduct(DeleteProductDto deleteProductDto);


       Task< ReadproductDto> SearchProductByName(string Name);
      Task< List<ReadproductDto>> SearchProductByCategory(int id);
        Task<List<ReadproductDto>> FilterProductByPrices(double Min, double Max);
        Task<List<ReadproductDto>> GetProductPaginated(int PageNumber, int PageSize);

        Task<IEnumerable<ReadproductDto>> FilterProductByRate(int rate);
        Task<IEnumerable<ReadproductDto>> FilterProductByAvailability(bool ava);

    }
}
