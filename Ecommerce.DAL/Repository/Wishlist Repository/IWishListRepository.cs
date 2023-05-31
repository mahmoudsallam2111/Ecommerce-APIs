using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public interface IwishListRepository:IGenericRepository<WishList>
    {
        Task<WishList> getWishListWithItems(int id);
    }
}
