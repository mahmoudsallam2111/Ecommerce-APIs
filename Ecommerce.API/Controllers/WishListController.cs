using Ecommerce.B;
using Ecommerce.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListManager wishListManager;

        public WishListController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wishlist =  await wishListManager.GetAll();
            return Ok(wishlist);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var wishlist = await wishListManager.GetById(id);
           return (wishlist == null) ? NotFound("Error while getting the Item") : Ok(wishlist);
        }


        [HttpGet]
        [Route("with-items/{id}")]
        public async Task<ActionResult<ReadwishlistwithItemsDto>> GetbyIdWithItems(int id)
        {
            var wishlist = await wishListManager.getWishListWithItems(id);
            return (wishlist == null) ? NotFound("Error while getting the Item") : Ok(wishlist);
        }

        [HttpPost]
        public async Task<ActionResult<ReadWishlistDto>> AddwishLiat(WriteWishlistDto writeWishlistDto)
        {
            return await wishListManager.AddWishList(writeWishlistDto);
        }


        [HttpDelete]
        public async Task<ActionResult<ReadWishlistDto>> AddwishLiat(DeleteWishlistDto deleteWishlistDto)
        {
            return await wishListManager.DeleteWishList(deleteWishlistDto);
        }


    }
}
