using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebJobsExtensions.CustomBindings.Slack.Client
{
    public class SlackClient: ISlackClient
    {
        private const string TargetMediaType = "application/json";
        private readonly string _incomingWebhookUrl;
        private readonly HttpClient _httpClient;

        public SlackClient(string incomingWebhookUrl, IHttpClientFactory httpClientFactory)
        {
            _incomingWebhookUrl = incomingWebhookUrl;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task SendMessageAsync(string payload)
        {
            var content = new StringContent(payload, Encoding.UTF8, TargetMediaType);
            var res = await _httpClient.PostAsync(_incomingWebhookUrl, content);
            res.EnsureSuccessStatusCode();
        }
    }
}