using System.Text.Json.Serialization;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class MarkdownBlock : BlockBase
    {
        [JsonPropertyName(BlockConstants.TypeKey)]
        public string Type => BlockConstants.Section;

        [JsonPropertyName(BlockConstants.Text)]
        public MarkdownSection Markdown { get; set; }

        [JsonPropertyName(BlockConstants.Accessory)]
        public ImageAccessorySection Accessory { get; set; }


        public MarkdownBlock(string text, TextTypeEnum type = TextTypeEnum.mrkdwn, string accessoryImageUrl = null)
        {
            Markdown = new MarkdownSection(text, type);

            if (!string.IsNullOrEmpty(accessoryImageUrl))
            {
                Accessory = new ImageAccessorySection(accessoryImageUrl);
            }
        }
    }
}