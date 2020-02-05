using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Microsoft.Extensions.Configuration;
using WebJobsExtensions.CustomBindings.Slack.Config;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class FunctionsHostBuilderExtensionsForSlack
    {
        public static IFunctionsHostBuilder AddSlackBinding(this IFunctionsHostBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddHttpClient();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IExtensionConfigProvider, SlackExtensionConfigProvider>());
            builder.Services.AddSingleton<ISlackClientFactory, SlackClientFactory>();


            builder.Services.AddOptions<SlackOptions>()
                .Configure<IConfiguration>((options, configuration) =>
                {
                    configuration.GetSection("Slack").Bind(options);
                });
            return builder;
        }
    }
}