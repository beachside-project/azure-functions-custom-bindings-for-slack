using System.Threading.Tasks;

namespace WebJobsExtensions.CustomBindings.Slack.Client
{
    public interface ISlackClient
    {
        Task SendMessageAsync(string payload);
    }
}