namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public static class LinkButtonBlockItemExtension
    {
        public static LinkButtonBlock AddLinkButtonElement(this LinkButtonBlock source, string buttonContext, string linkUrl)
        {
            var button = new LinkButtonElement(buttonContext, linkUrl);
            source.Elements.Add(button);
            return source;
        }
    }
}