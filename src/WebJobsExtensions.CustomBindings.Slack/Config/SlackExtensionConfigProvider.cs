﻿using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using WebJobsExtensions.CustomBindings.Slack.Bindings;
using WebJobsExtensions.CustomBindings.Slack.Client;

namespace WebJobsExtensions.CustomBindings.Slack.Config
{
    internal class SlackExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly SlackOptions _options;
        private readonly ISlackClientFactory _slackClientFactory;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ConcurrentDictionary<string, ISlackClient> _slackClientCache = new ConcurrentDictionary<string, ISlackClient>();

        public SlackExtensionConfigProvider(IOptions<SlackOptions> options, ISlackClientFactory slackClientFactory, IHttpClientFactory httpClientFactory)
        {
            _options = options.Value;
            _slackClientFactory = slackClientFactory;
            _httpClientFactory = httpClientFactory;
        }


        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var rule = context.AddBindingRule<SlackAttribute>();
            rule.AddValidator(ValidateBinding);
            rule.BindToCollector(CreateCollector);
        }


        internal IAsyncCollector<string> CreateCollector(SlackAttribute attribute)
        {
            var url = GetFirstOrDefault(attribute.IncomingWebhookUrl, _options.IncomingWebhookUrl);
            var client =_slackClientCache.GetOrAdd(url, u => _slackClientFactory.Create(u, _httpClientFactory));
            return new SlackAsyncCollector(client);
        }


        internal void ValidateBinding(SlackAttribute attribute, Type type)
        {
            var url = GetFirstOrDefault(attribute.IncomingWebhookUrl, _options.IncomingWebhookUrl);
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("need to set Slack IncomingWebhookUrl to AppSettings or Slack Attribute.");

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException($"IncomingWebhookUrl is invalid HTTP scheme.(value: {url}");
        }


        private static string GetFirstOrDefault(params string[] values) => values.FirstOrDefault(v => !string.IsNullOrEmpty(v));
    }
}