using Microsoft.Azure.WebJobs;
using WebJobsExtensions.CustomBindings.Slack.Config;

namespace WebJobsExtensions.CustomBindings.Slack.Bindings
{
    internal class SlackAsyncCollectorBuilder<T> : IConverter<SlackAttribute, IAsyncCollector<T>>
    {
        private readonly SlackExtensionConfigProvider _slackExtensionConfigProvider;

        internal SlackAsyncCollectorBuilder(SlackExtensionConfigProvider slackExtensionConfigProvider)
        {
            _slackExtensionConfigProvider = slackExtensionConfigProvider;
        }

        public IAsyncCollector<T> Convert(SlackAttribute attribute)
        {
            var collector = _slackExtensionConfigProvider.CreateCollector<T>(attribute);
            return collector;
        }
    }
}