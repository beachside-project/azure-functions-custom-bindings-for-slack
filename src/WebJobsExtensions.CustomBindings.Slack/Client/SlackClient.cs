using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.Slack.Models;

namespace WebJobsExtensions.CustomBindings.Slack.Client
{
    public class SlackClient : ISlackClient
    {
        private const string TargetMediaType = "application/json";
        private readonly string _incomingWebhookUrl;
        private readonly HttpClient _httpClient;

        public SlackClient(string incomingWebhookUrl, IHttpClientFactory httpClientFactory)
        {
            _incomingWebhookUrl = incomingWebhookUrl;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task SendMessageAsync<T>(T input)
        {
            switch (input)
            {
                case string payload:
                    await SendToSlackAsync(_incomingWebhookUrl, payload);
                    break;
                case SlackInput obj:
                    await SendToSlackAsync(obj.IncomingWebhookUrl, obj.Payload);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(input));
            }
        }

        private async Task SendToSlackAsync(string url, string payload)
        {
            var content = new StringContent(payload, Encoding.UTF8, TargetMediaType);
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
    }
}