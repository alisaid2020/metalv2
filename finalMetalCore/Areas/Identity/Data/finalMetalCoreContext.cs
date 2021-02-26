using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalMetalCore.Areas.Identity.Data;
using finalMetalCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace finalMetalCore.Areas.Identity.Data
{
    public class finalMetalCoreContext : IdentityDbContext<finalMetalCoreUser>
    {
        public finalMetalCoreContext(DbContextOptions<finalMetalCoreContext> options)
            : base(options)
        {
        }
        public DbSet<product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
