using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class LinkButtonBlock : BlockBase
    {
        [JsonPropertyName(BlockConstants.TypeKey)]
        public string Type => BlockConstants.Actions;


        [JsonPropertyName(BlockConstants.Elements)]
        public List<LinkButtonElement> Elements { get; set; } = new List<LinkButtonElement>();

    }

    public class LinkButtonElement
    {
        [JsonPropertyName(BlockConstants.TypeKey)]
        public string Type => ElementTypeEnum.button.ToString();

        [JsonPropertyName(BlockConstants.Text)]
        public MarkdownSection Text { get; }

        [JsonPropertyName(BlockConstants.Style)]
        public string Style { get; }

        [JsonPropertyName(BlockConstants.Url)]
        public string Url { get; }

        public LinkButtonElement(string buttonContent, string linkUrl, ButtonStyle buttonStyle = ButtonStyle.primary)
        {
            Text = new MarkdownSection(buttonContent, TextTypeEnum.plain_text);
            Url = linkUrl;
            Style = buttonStyle.ToString();
        }
    }
}