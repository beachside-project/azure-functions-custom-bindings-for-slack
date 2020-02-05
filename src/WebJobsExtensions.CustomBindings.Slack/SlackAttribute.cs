using Microsoft.Azure.WebJobs.Description;
using System;

namespace WebJobsExtensions.CustomBindings.Slack
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class SlackAttribute : Attribute
    {
        [AppSetting(Default = "Slack:IncomingWebhookUrl")]
        public string IncomingWebhookUrl { get; set; }
    }
}