using Ecommerce.B;
using Ecommerce.BL;
using Ecommerce.BL.Dtos.WishItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishItemController : ControllerBase
    {
        private readonly IWshItemManager wshItemManager;

        public WishItemController(IWshItemManager wshItemManager)
        {
            this.wshItemManager = wshItemManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wishitemlist = await wshItemManager.GetAll();
            return Ok(wishitemlist);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var wishitem = await wshItemManager.GetById(id);
            return (wishitem==null) ? NotFound("error while grtting tje item")  : Ok(wishitem);
        }


        [HttpPost]
        public async Task<ActionResult<ReadWishItemDto>> Addwishitem(WriteWishItemDto writeWishItemDto)
        {
            return await wshItemManager.AddWishItem(writeWishItemDto);
        }

        [HttpDelete
            ]
        public async Task<ActionResult<ReadWishItemDto>> Deletewishitem(DeleteWishItemDto deleteWishItemDto)
        {
            return await wshItemManager.deleteWishItem(deleteWishItemDto);
        }


    }
}
