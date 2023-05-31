using Ecommerce.BL;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.B
{
    public interface IWishListManager
    {
        Task<List<ReadWishlistDto>> GetAll();
        Task<ReadWishlistDto?> GetById(int id);
        Task<ReadwishlistwithItemsDto> getWishListWithItems(int id);


        Task<ReadWishlistDto> AddWishList(WriteWishlistDto writeWishlistDto);

        Task<ReadWishlistDto> UpdateWishList(WriteWishlistDto writeWishlistDto);

        Task<ReadWishlistDto> DeleteWishList(DeleteWishlistDto deleteWishlistDto);
    }
}
