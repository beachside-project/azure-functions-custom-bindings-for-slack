using System.Text.Json.Serialization;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class ImageAccessorySection
    {
        [JsonPropertyName(BlockConstants.TypeKey)]
        public string Type => AccessoryTypeEnum.image.ToString();

        [JsonPropertyName(BlockConstants.ImageUrl)]
        public string ImageUrl { get; }

        [JsonPropertyName(BlockConstants.AltText)]
        public string AltText => "image";

        public ImageAccessorySection(string accessoryImageUrl)
        {
            ImageUrl = accessoryImageUrl;
        }
    }
}