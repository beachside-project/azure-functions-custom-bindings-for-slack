using WebJobsExtensions.CustomBindings.Slack.BlockKit;

namespace WebJobsExtensions.CustomBindings.Slack
{
    public class SlackMessageHelper
    {
        private const string SimpleTextTemplate = "{{\"text\":\"{0}\"}}";

        private const string EventNotificationMessageTemplate = "{0} \n\n *Event:*       {1} \n *Updater:*  {2}";
        private const string AdditionalMessageTemplate = " \n *Timeline:*  {0}";
        private const string SampleAccessoryImageUrl = @"https://www.techielass.com/wp-content/uploads/2019/09/Microsoft-Azure-Cloud-Advocate-300x300.jpg";


        /// <summary>
        /// Create simple text format: {"text": "your text"}
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>
        /// Markdown for Slack is available.
        /// </remarks>
        public static string CreateSimplePayload(string text) => string.Format(SimpleTextTemplate, text);


        /// <summary>
        /// Create BlockKit Sample format
        /// </summary>
        /// <param name="title"></param>
        /// <param name="buttonText"></param>
        /// <param name="buttonActionLinkUrl"></param>
        /// <param name="description"></param>
        /// <param name="eventName"></param>
        /// <param name="updateUser"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public static string CreateEventNotificationMessage(
            string title,
            string buttonText,
            string buttonActionLinkUrl,
            string description,
            string eventName,
            string updateUser, 
            string detail = null)
        {
            var message = CreateEventNotificationMessage(description, eventName, updateUser, detail);

            var json = new BlockKitBuilder()
                .AddMarkdownBlock(":pushpin: " + title)
                .AddMarkdownBlock(message, SampleAccessoryImageUrl)
                .AddLinkButtonBlock(buttonText, buttonActionLinkUrl)
                .AddDividerBlock()
                .ToBuildJson();
            return json;
        }


        private static string CreateEventNotificationMessage(string description, string eventName, string updater, string detail)
        {
            var payload = string.Format(EventNotificationMessageTemplate, description, eventName, updater);
            if (!string.IsNullOrEmpty(detail))
            {
                payload += string.Format(AdditionalMessageTemplate, detail);
            }

            return payload;
        }
    }
}