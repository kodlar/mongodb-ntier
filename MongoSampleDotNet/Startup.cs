using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoSampleDotNet.Startup))]
namespace MongoSampleDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
