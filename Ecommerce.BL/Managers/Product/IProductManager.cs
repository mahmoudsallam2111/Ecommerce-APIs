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
        IEnumerable<ReadproductDto> GetAll();
        ReadproductDto GetProductById(int id);
        ReadproductDto AddProduct(WriteProductDto writeProductDto);
        ReadproductDto RemoveProduct(DeleteProductDto deleteProductDto);


        ReadproductDto SearchProductByName(string Name);
       List<ReadproductDto> SearchProductByCategory(int id);
        List<ReadproductDto> FilterProductByPrices(double Min, double Max);
        List<ReadproductDto> GetProductPaginated(int PageNumber, int PageSize);

        IEnumerable<ReadproductDto> FilterProductByRate(int rate);
        IEnumerable<ReadproductDto> FilterProductByAvailability(bool ava);

    }
}
