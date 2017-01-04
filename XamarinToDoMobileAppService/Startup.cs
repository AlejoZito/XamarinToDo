using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinToDoMobileAppService.Startup))]

namespace XamarinToDoMobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}