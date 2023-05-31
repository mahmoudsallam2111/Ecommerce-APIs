using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class WishlistRepository : GenericRepository<WishList>, IwishListRepository
    {
        private readonly EcommerceDB context;

        public WishlistRepository(EcommerceDB Context) : base(Context)
        {
            context = Context;
        }

        public async Task<WishList> getWishListWithItems(int id)
        {
            var res = await context.wishLists
         .AsNoTrackingWithIdentityResolution()      
         .Include(wl => wl.wishItems)
         //.ThenInclude(wi => wi.Product)
         .FirstOrDefaultAsync(wl => wl.ID == id);

         
            /// this a work around solution to prevent circular reference
            //foreach (var item in res.wishItems)
            //{
            //    item.WishList = null;
            //}

            return res;
        }
    }
}
