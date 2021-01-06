namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class BlockKitAttachmentBuilder : BlockKitBuilder
    {
        public string ColorCode { get; set; }

        public BlockKitAttachmentBuilder(string colorCode)
        {
            ColorCode = colorCode;
        }

        public override string ToBuildJson()
        {
            // TODO: validation
            var items = string.Join(Separator, _blockItems);
            return $"{{\"attachments\": [{{\"color\": \"{ColorCode}\", \"blocks\": [{items}]}}]}}";
        }
    }
}