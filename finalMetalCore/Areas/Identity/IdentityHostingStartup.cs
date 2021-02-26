using System;
using finalMetalCore.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(finalMetalCore.Areas.Identity.IdentityHostingStartup))]
namespace finalMetalCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<finalMetalCoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("finalMetalCoreContextConnection")));

                services.AddDefaultIdentity<finalMetalCoreUser>(options => { 
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password = new PasswordOptions()
                    {
                        RequireDigit=false,
                        RequiredLength=6,
                        RequireNonAlphanumeric=false,
                        RequiredUniqueChars=0
                    };
                }
                ).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<finalMetalCoreContext>();
            });
        }
    }
}