using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScheduleTravel.Startup))]
namespace ScheduleTravel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
