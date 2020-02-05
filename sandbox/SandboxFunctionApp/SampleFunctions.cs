using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.Slack;

namespace SandboxFunctionApp
{
    public class SampleFunctions
    {
        [FunctionName("Function1")]
        public async Task<IActionResult> SendSimpleText(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Slack(IncomingWebhookUrl = "Slack:IncomingWebhookUrl")]IAsyncCollector<string> asyncCollector,
            ILogger log)
        {
            var text = $"Hello *Slack*: {DateTime.Now}";
            var payload = SlackMessageHelper.CreateSimplePayload(text);

            await asyncCollector.AddAsync(payload);

            return new OkObjectResult("Hello");
        }


        [FunctionName("Function2")]
        public async Task<IActionResult> SendBlockKitFormat(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Slack(IncomingWebhookUrl = "Slack:IncomingWebhookUrl")]IAsyncCollector<string> asyncCollector,
            ILogger log)
        {
            var title = "*#14 How to use Worker Services?*";
            var description = "xxx で更新がありました。";
            var eventName = "Added Timeline";
            var updater = "鈴木イチロー";
            var detail = "xxx の動作はxxx から起動します...";

            var image = @"https://www.techielass.com/wp-content/uploads/2019/09/Microsoft-Azure-Cloud-Advocate-300x300.jpg";

            var payload = SlackMessageHelper.CreateEventNotificationMessage(
                title,
                "View More",
                image,
                description,
                eventName,
                updater,
                detail
            );

            await asyncCollector.AddAsync(payload);

            return new OkObjectResult("Hello");
        }
    }
}