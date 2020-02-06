using Microsoft.Azure.WebJobs.Description;
using System;

namespace WebJobsExtensions.CustomBindings.Slack
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public sealed class SlackAttribute : Attribute
    {
        [AutoResolve]
        public string IncomingWebhookUrl { get; set; }

        [AutoResolve]
        public string IsDynamicUrl { get; set; } = "false";

        public bool IsDynamic => Convert.ToBoolean(IsDynamicUrl);
    }
}