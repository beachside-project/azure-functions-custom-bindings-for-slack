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
        /// IsDynamicUrl:true �� IsDynamicUrl:false �̃��\�b�h�́A ���� Function �ł͋����ł��܂���B
        /// SlackAttribute �� IAsyncCollector�� Generics �ˑ��֌W�̂��߂ł��B
        /// Attribute �𕪂��ċ����\�ɂ��悤���Ƃ��v���܂������A���̃��[�X�P�[�X���Ȃ����߁AAttribute ��1�ŋ����ł��Ȃ������ɂ��Ă����܂��B
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