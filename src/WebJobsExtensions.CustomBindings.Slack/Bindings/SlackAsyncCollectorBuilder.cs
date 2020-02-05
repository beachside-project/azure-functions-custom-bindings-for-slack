using Microsoft.Azure.WebJobs;
using WebJobsExtensions.CustomBindings.Slack.Config;

namespace WebJobsExtensions.CustomBindings.Slack.Bindings
{
    internal class SlackAsyncCollectorBuilder : IConverter<SlackAttribute, IAsyncCollector<string>>
    {
        private readonly SlackExtensionConfigProvider _slackExtensionConfigProvider;

        internal SlackAsyncCollectorBuilder(SlackExtensionConfigProvider slackExtensionConfigProvider)
        {
            _slackExtensionConfigProvider = slackExtensionConfigProvider;
        }

        public IAsyncCollector<string> Convert(SlackAttribute attribute)
        {
            var collector = _slackExtensionConfigProvider.CreateCollector(attribute);
            return collector;
        }
    }
}