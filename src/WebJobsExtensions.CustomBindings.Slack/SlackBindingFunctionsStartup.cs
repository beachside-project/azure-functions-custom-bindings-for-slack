using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebJobsExtensions.CustomBindings.Slack;

[assembly: FunctionsStartup(typeof(SlackBindingFunctionsStartup))]
namespace WebJobsExtensions.CustomBindings.Slack
{
    public class SlackBindingFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddSlackBinding();
        }
    }
}