using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.Models;
using Owin;

[assembly: OwinStartup(typeof(OnlineShoppingStore.Startup))]
namespace OnlineShoppingStore
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperConfig.Init();
        }

    }
}
