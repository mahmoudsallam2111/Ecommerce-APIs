using Ecommerce.B;
using Ecommerce.BL.Dtos.WishItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public interface IWshItemManager
    {
        Task<List<ReadWishItemDto>> GetAll();
        Task<ReadWishItemDto?> GetById(int id);

        Task<ReadWishItemDto> AddWishItem(WriteWishItemDto writeWishItemDto);
        Task<ReadWishItemDto> UpdateWishItem(WriteWishItemDto writeWishItemDto);
        Task<ReadWishItemDto> deleteWishItem(DeleteWishItemDto deleteWishItemDto);


    }
}
