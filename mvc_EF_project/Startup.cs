using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_EF_project.Startup))]
namespace mvc_EF_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
