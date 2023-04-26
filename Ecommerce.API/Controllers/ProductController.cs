using Ecommerce.BL;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        //[Authorize(Policy = "AdminsOnly")]
        public ActionResult<List<ReadproductDto>> GetAllProduct()
        {
            return productManager.GetAll().ToList();
        }


        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = "Admins_users")]
        public ActionResult<ReadproductDto> GetProductById(int id)
        {
            return productManager.GetProductById(id);
        }



        [HttpGet]
        [Route("SearchProductByName")]
        public ActionResult<ReadproductDto> SearchProductByName(string Name)
        {
            var _product = productManager.SearchProductByName(Name);
            if (_product == null)
            {
                return NotFound();
            }
            return _product;

        }




        [HttpGet]
        [Route("{min}/{max}")]
        public ActionResult<List<ReadproductDto>> FilterProductByPrice(double min, double max)
        {
            return productManager.FilterProductByPrices(min, max);
        }


        [HttpGet]
        [Route("GetProductPaginated/{PageNumber}/{PageSize}")]
        public ActionResult<List<ReadproductDto>> GetProductPaginated(int PageNumber, int PageSize)
        {
            return productManager.GetProductPaginated(PageNumber, PageSize);
        }



        [HttpGet]
        [Route("SearchProductByCategory")]
        public ActionResult<List<ReadproductDto>> SearchProductByCategory(int id)
        {
              var SearchedProduct  =  productManager.SearchProductByCategory(id);

            if (SearchedProduct.Count() == 0)
            {
                return Ok("This category Does not Contain Any Product Yet Or its not Created");
            }

            return SearchedProduct;
        }

        [HttpGet]
        [Route("FilterProductByRate/{rate}")]
        public ActionResult<List<ReadproductDto>> FilterProductByRate(int rate)
        {
             var productList =   productManager.FilterProductByRate(rate).ToList();
            if (productList.Count()==0)
            {
                return Ok("There is no Element of This rate");
            }
            return productList;
        }

        [HttpGet]
        [Route("FilterProductByAvailability/{ava}")]
        public ActionResult<List<ReadproductDto>> FilterProductByAvailability(bool ava)
        {
            return productManager.FilterProductByAvailability(ava).ToList();
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public ActionResult<ReadproductDto> AddNewProduct(WriteProductDto writeProductDto)
        {

            return productManager.AddProduct(writeProductDto);

        }


        [HttpDelete]
        [Route("RemoveProduct")]
        public ActionResult<ReadproductDto> RemoveProduct(DeleteProductDto deleteProductDto)
        {
            return productManager.RemoveProduct(deleteProductDto);
        }



    }
}
