using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAngular2.EF
{
    public class MainDBContext: IdentityDbContext<User>
    {
        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserBuy> UserBuys { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductBuy> ProductBuys { get; set; }
    }
}
