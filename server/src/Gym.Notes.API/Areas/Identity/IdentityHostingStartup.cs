using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Gym.Notes.API.Areas.Identity.IdentityHostingStartup))]
namespace Gym.Notes.API.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => 
            { 
            });
        }
    }
}