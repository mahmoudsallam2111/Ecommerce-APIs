using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class CategoryRepository:GenericRepository<Category> , ICategoryRepository
    {
        private readonly EcommerceDB context;

        public CategoryRepository(EcommerceDB Context):base(Context)
        {
            context = Context;
        }

      
    }
}
