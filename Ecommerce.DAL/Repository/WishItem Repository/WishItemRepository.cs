using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class WishItemRepository : GenericRepository<WishItem>, IWishItemRepository
    {
        private readonly EcommerceDB context;

        public WishItemRepository(EcommerceDB Context) : base(Context)
        {
            context = Context;
        }
    }
}
