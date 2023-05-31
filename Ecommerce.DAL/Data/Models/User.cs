using Ecommerce.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class User:IdentityUser
    {
        public virtual ICollection<Order> Products { get; set; } = new HashSet<Order>();
        public WishList? WishList { get; set; }

    }
}
