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
        public async Task<IActionResult> GetAllProduct()
        {
            var ProductList = await productManager.GetAll();
            return Ok(ProductList);
        }


        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = "Admins_users")]
        public async Task<IActionResult> GetProductById(int id)
        {
               var product = await productManager.GetProductById(id);
            return (product == null) ? NotFound("error while getting the item") : Ok(product);
        }



        [HttpGet]
        [Route("SearchProductByName")]
        public async Task<IActionResult> SearchProductByName(string Name)
        {
            var _product = await productManager.SearchProductByName(Name);
           return (_product == null) ? NotFound("The product Does not Exist") : Ok(_product);
        }




        [HttpGet]
        [Route("{min}/{max}")]
        public async Task<IActionResult> FilterProductByPrice(double min, double max)
        {
             var productlist = await productManager.FilterProductByPrices(min, max);

            return Ok(productlist);
        }


        [HttpGet]
        [Route("GetProductPaginated/{PageNumber}/{PageSize}")]
        public async Task<IActionResult> GetProductPaginated(int PageNumber, int PageSize)
        {
            return Ok(await productManager.GetProductPaginated(PageNumber, PageSize));
        }



        [HttpGet]
        [Route("SearchProductByCategory")]
        public async Task<ActionResult<List<ReadproductDto>>> SearchProductByCategory(int id)
        {
              var SearchedProduct  = await productManager.SearchProductByCategory(id);

            if (SearchedProduct.Count() == 0)
            {
                return Ok("This category Does not Contain Any Product Yet Or its not Created");
            }

            return SearchedProduct;
        }

        [HttpGet]
        [Route("FilterProductByRate/{rate}")]
        public async Task<ActionResult<List<ReadproductDto>>> FilterProductByRate(int rate)
        {
             var productList =  await productManager.FilterProductByRate(rate);
            if (productList.Count()==0)
            {
                return Ok("There is no Element of This rate");
            }
            return Ok(productList);
        }

        [HttpGet]
        [Route("FilterProductByAvailability/{ava}")]
        public async Task< ActionResult<List<ReadproductDto>>> FilterProductByAvailability(bool ava)
        {
            return Ok(await productManager.FilterProductByAvailability(ava));
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task< ActionResult<ReadproductDto> >AddNewProduct(WriteProductDto writeProductDto)
        {

            return Ok(await productManager.AddProduct(writeProductDto));

        }


        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task< ActionResult<ReadproductDto>> RemoveProduct(DeleteProductDto deleteProductDto)
        {
            return  Ok(await productManager.RemoveProduct(deleteProductDto));
        }



    }
}
