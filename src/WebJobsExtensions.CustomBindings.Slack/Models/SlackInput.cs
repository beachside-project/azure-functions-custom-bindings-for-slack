namespace WebJobsExtensions.CustomBindings.Slack.Models
{
    public class SlackInput
    {
        public string IncomingWebhookUrl { get; set; }
        public string Payload { get; set; }
    }
}