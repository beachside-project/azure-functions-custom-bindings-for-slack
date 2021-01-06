using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.Slack;
using WebJobsExtensions.CustomBindings.Slack.BlockKit;

namespace SandboxFunctionApp
{
    public class SampleFunctions
    {
        #region Slack(IsDynamicUrl = "false")

        [FunctionName("Function1")]
        public async Task<IActionResult> SendSimpleText(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Slack(IncomingWebhookUrl = "%Slack:IncomingWebhookUrl%")] IAsyncCollector<string> asyncCollector,
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
            [Slack(IncomingWebhookUrl = "%Slack:IncomingWebhookUrl%")] IAsyncCollector<string> asyncCollector,
            ILogger log)
        {
            var title = "*#28 App Service �T�C�R�[�ł��I*";
            var description = "xxx �ōX�V������܂����B";
            var eventName = "Added Timeline";
            var updater = "GEEK: ��؃C�`���[ ";
            var detail = "WebApps�Ƀf�v���C�����A�v���P�[�V�����Ƀu���E�U����A�N�Z�X�����ۂ� HTTP����431 Request Header Fields Too Large ���Ԃ���A�A�N�Z�X�����s����ꍇ������܂��B �Ώ����@�������Ă��������B��̃R�����g�ŁA�Ⴄ�[�����玟��API�ɃA�N�Z�X�����ۂ�HTTP�w�b�_���L�ڂ��܂�...";


            var buttonLink = @"http://docs.microsoft.com/";

            var payload = SlackMessageHelper.CreateEventNotificationMessageSample(
                title,
                "View More",
                buttonLink,
                description,
                eventName,
                updater,
                detail
            );

            await asyncCollector.AddAsync(payload);

            return new OkObjectResult("Hello");
        }

        [FunctionName("Function3")]
        public async Task<IActionResult> SendAttachment(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Slack(IncomingWebhookUrl = "%Slack:IncomingWebhookUrl%")] IAsyncCollector<string> asyncCollector,
            ILogger log)
        {
            var text = $"Hello *Slack*: {DateTime.Now}";

            var payload = new BlockKitAttachmentBuilder("#65ACB4")
                .AddMarkdownBlock(":pushpin: " + text)
                .AddLinkButtonBlock("Go to Docs", "https://docs.microsoft.com/")
                .ToBuildJson();

            await asyncCollector.AddAsync(payload);

            return new OkObjectResult("Hello");
        }

        #endregion Slack(IsDynamicUrl = "false")

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
        //[FunctionName("Function3")]
        //public async Task<IActionResult> SendSimpleTextWithDynamicUrl(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] SlackInput input,
        //    [Slack(IsDynamicUrl = "true")]IAsyncCollector<SlackInput> asyncCollector,
        //    ILogger log)
        //{
        //    var text = $"Hello *Slack*: {DateTime.Now}";
        //    input.Payload = SlackMessageHelper.CreateSimplePayload(text);

        //    await asyncCollector.AddAsync(input);

        //    return new OkObjectResult("Hello");
        //}

        #endregion Slack(IsDynamicUrl = "true")
    }
}