using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinToDoWebApi.Startup))]

namespace XamarinToDoWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}