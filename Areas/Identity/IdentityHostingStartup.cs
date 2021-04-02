using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PrivateOffice2.Areas.Identity.IdentityHostingStartup))]
namespace PrivateOffice2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}