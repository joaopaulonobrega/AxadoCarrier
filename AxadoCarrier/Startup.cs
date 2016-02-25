using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AxadoCarrier.Startup))]
namespace AxadoCarrier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
