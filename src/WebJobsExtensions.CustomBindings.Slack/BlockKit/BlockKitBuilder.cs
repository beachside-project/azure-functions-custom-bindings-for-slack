﻿using System.Collections.Generic;

namespace WebJobsExtensions.CustomBindings.Slack.BlockKit
{
    public class BlockKitBuilder
    {
        protected const string Separator = ",";
        protected readonly List<string> _blockItems = new List<string>();

        public void AddBlockJson(string json)
        {
            _blockItems.Add(json);
        }

        /// <summary>
        /// Generate payload as json.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// You can validate the generated payload: https://api.slack.com/tools/block-kit-builder.
        /// </remarks>
        public virtual string ToBuildJson()
        {
            // TODO: validation
            var items = string.Join(Separator, _blockItems);
            return $"{{\"blocks\": [{items}]}}";
        }
    }
}
