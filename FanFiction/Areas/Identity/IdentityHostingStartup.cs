using FanFiction.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FanFiction.Areas.Identity.IdentityHostingStartup))]
namespace FanFiction.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        private IConfigurationRoot _confstring;

        public IdentityHostingStartup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((services) => {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}