// ReSharper disable InconsistentNaming
namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public struct BlockConstants
    {
        public const string TypeKey = "type";
        public const string Section = "section";
        public const string Actions = "actions";
        public const string Text = "text";
        public const string ImageUrl = "image_url";
        public const string AltText = "alt_text";
        public const string Accessory = "accessory";
        public const string Style = "style";
        public const string Url = "url";
        public const string Elements = "elements";
    }

    public enum TextTypeEnum
    {
        mrkdwn,
        plain_text
    }

    public enum ButtonStyle
    {
        primary
    }

    public enum AccessoryTypeEnum
    {
        image
    }

    public enum ElementTypeEnum
    {
        button
    }
}