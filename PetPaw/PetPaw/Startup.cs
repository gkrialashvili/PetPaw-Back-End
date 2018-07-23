using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetPaw.Startup))]
namespace PetPaw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
