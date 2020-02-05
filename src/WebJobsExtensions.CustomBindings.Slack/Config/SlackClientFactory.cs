using System.Net.Http;
using WebJobsExtensions.CustomBindings.Slack.Client;

namespace WebJobsExtensions.CustomBindings.Slack.Config
{
    public class SlackClientFactory : ISlackClientFactory
    {
        public ISlackClient Create(string incomingWebhookUrl, IHttpClientFactory httpClientFactory)
            => new SlackClient(incomingWebhookUrl, httpClientFactory);
    }
}