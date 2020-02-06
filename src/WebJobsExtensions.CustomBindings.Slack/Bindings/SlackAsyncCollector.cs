using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.Slack.Client;

namespace WebJobsExtensions.CustomBindings.Slack.Bindings
{
    internal class SlackAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly ISlackClient _slackClient;

        public SlackAsyncCollector(ISlackClient slackClient)
        {
            _slackClient = slackClient;
        }

        public async Task AddAsync(T payload, CancellationToken cancellationToken = new CancellationToken())
        {
            await _slackClient.SendMessageAsync(payload);
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken()) => Task.CompletedTask;
    }
}