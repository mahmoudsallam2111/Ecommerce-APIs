using Ecommerce.DA;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class EcommerceDB : IdentityDbContext<User>
    {
        public EcommerceDB(DbContextOptions<EcommerceDB> options) : base(options)
        {
        }

        //public DbSet<User> Users => Set<User>();   /// not done
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> orderItems => Set<OrderItem>();
        public DbSet<DeliveryMethod> deliveryMethods => Set<DeliveryMethod>();


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

        }
    }
}
