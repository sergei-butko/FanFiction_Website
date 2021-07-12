using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FanFiction.Areas.Identity.IdentityHostingStartup))]

namespace FanFiction.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}