using System.Text.Json;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class BlockBase
    {
        public string ToJson() => JsonSerializer.Serialize<object>(this);
        public string ToJson(JsonSerializerOptions options) => JsonSerializer.Serialize<object>(this, options);
    }
}