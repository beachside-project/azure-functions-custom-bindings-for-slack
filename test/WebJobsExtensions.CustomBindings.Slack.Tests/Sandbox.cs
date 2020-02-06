using System;
using Xunit;

namespace WebJobsExtensions.CustomBindings.Slack.Tests
{
    public class Sandbox
    {
        [Fact]
        public void Test1()
        {
            var title = "*#14 How to use Worker Services?*";
            var description = "xxx で更新がありました。";
            var eventName = "Added Timeline";
            var updater = "鈴木イチロー";
            var detail = "xxx の動作はxxx から起動します...";

            var image = @"https://www.techielass.com/wp-content/uploads/2019/09/Microsoft-Azure-Cloud-Advocate-300x300.jpg";


            var message = SlackMessageHelper.CreateEventNotificationMessageSample(
                title,
                "View More",
                image,
                description,
                eventName,
                updater,
                detail
            );

            Console.WriteLine();
        }
    }
}