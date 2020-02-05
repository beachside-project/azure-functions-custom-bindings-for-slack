using System.Text.Json.Serialization;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class MarkdownSection
    {
        [JsonPropertyName(BlockConstants.TypeKey)]
        public string Type { get; }

        [JsonPropertyName(BlockConstants.Text)]
        public string Text { get; }


        public MarkdownSection(string text, TextTypeEnum type)
        {
            Text = text;
            Type = type.ToString();
        }
    }
}