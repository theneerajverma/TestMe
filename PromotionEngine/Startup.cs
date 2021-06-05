using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PromotionEngine.Startup))]
namespace PromotionEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
