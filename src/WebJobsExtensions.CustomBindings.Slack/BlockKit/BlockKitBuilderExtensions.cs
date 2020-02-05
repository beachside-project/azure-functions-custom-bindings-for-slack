using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public static class BlockKitBuilderExtensions
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            IgnoreNullValues = true,
            IgnoreReadOnlyProperties = false,
            WriteIndented = true
        };

        public static BlockKitBuilder AddDividerBlock(this BlockKitBuilder builder)
        {
            builder.AddBlockJson("{\"type\": \"divider\"}");
            return builder;
        }

        public static BlockKitBuilder AddMarkdownBlock(this BlockKitBuilder builder, string text, string accessoryImageUrl = null)
        {
            var json = new MarkdownBlock(text, accessoryImageUrl: accessoryImageUrl).ToJson(Options);
            builder.AddBlockJson(json);
            return builder;
        }

        public static BlockKitBuilder AddLinkButtonBlock(this BlockKitBuilder builder, string buttonText, string linkUrl, ButtonStyle buttonStyle = ButtonStyle.primary)
        {
            var json = new LinkButtonBlock()
                .AddLinkButtonElement(buttonText, linkUrl)
                .ToJson(Options);
            builder.AddBlockJson(json);
            return builder;
        }
    }
}