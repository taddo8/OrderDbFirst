using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderDbFirst.Startup))]
namespace OrderDbFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
