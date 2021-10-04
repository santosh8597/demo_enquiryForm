using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentEnquiry.Startup))]
namespace StudentEnquiry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
