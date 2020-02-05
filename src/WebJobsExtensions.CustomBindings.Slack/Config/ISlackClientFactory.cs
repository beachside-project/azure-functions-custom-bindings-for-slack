using System.Net.Http;
using WebJobsExtensions.CustomBindings.Slack.Client;

namespace WebJobsExtensions.CustomBindings.Slack.Config
{
    public interface ISlackClientFactory
    {
        ISlackClient Create(string incomingWebhookUlr, IHttpClientFactory httpClientFactory);
    }
}