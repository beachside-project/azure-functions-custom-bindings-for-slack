using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WebJobsExtensions.CustomBindings.Slack;
using WebJobsExtensions.CustomBindings.Slack.Models;

namespace SandboxFunctionsV3
{
    public static class QueueTriggerSamples
    {
        [FunctionName("QueueTriggerSamples")]
        public static async Task Run([QueueTrigger("slack-notification")]SimpleTextForDynamicUrlModel input,
            [Slack(IsDynamicUrl = "true")]IAsyncCollector<SlackInput> asyncCollector,
            ILogger log)
        {
            // queue �� json sample:
            // { "IncomingWebhookUrl": "", "Text": "Hello Slack" }

            var slackInput = new SlackInput
            {
                IncomingWebhookUrl = input.IncomingWebhookUrl,
                Payload = SlackMessageHelper.CreateSimplePayload(input.Text)
            };

            await asyncCollector.AddAsync(slackInput);
        }

        // Slack �� BlockKit �𗘗p�������b�Z�[�W��ʒm�������ꍇ��
        // WebJobsExtensions.CustomBindings.Slack.SlackMessageHelper ��
        // ���p���āASlackInput �𑗐M������Ɗy�� SlackInput ���\���ł��܂��B
    }
}