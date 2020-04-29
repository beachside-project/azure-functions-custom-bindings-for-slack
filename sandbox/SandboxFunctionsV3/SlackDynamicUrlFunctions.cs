using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.Slack;
using WebJobsExtensions.CustomBindings.Slack.Models;

namespace SandboxFunctionsV3
{
    public class SlackDynamicUrlFunctions
    {
        #region Slack(IsDynamicUrl = "true")

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <param name="asyncCollector"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        /// <remarks>
        /// IsDynamicUrl:true と IsDynamicUrl:false のメソッドは、 同一 Function では共存できません。
        /// SlackAttribute と IAsyncCollectorの Generics 依存関係のためです。
        /// Attribute を分けて共存可能にしようかとも思いましたが、そのユースケースがないため、Attribute は1つで共存できない実装にしていいます。
        /// </remarks>
        [FunctionName("Function3")]
        public async Task<IActionResult> SendSimpleTextWithDynamicUrl(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] SlackInput input,
            [Slack(IsDynamicUrl = "true")]IAsyncCollector<SlackInput> asyncCollector,
            ILogger log)
        {
            var text = $"Hello *Slack*: {DateTime.Now}";
            input.Payload = SlackMessageHelper.CreateSimplePayload(text);

            await asyncCollector.AddAsync(input);

            return new OkObjectResult("Hello");
        }

        #endregion Slack(IsDynamicUrl = "true")
    }
}