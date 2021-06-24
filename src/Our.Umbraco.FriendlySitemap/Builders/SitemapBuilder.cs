using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Extensions;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    internal class SitemapBuilder : SitemapBuilderBase<SitemapConfiguration>
    {
        private readonly XNamespace _xmlns = XNamespace.Get("http://www.w3.org/1999/xhtml");

        private readonly SitemapConfiguration _config;

        public SitemapBuilder(SitemapConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public override XElement BuildUrlSetElement(IPublishedContent node, string culture)
        {
            var urlsetElement = base.BuildUrlSetElement(node, culture);

            urlsetElement.AddNamespace("xhtml", _xmlns);

            return urlsetElement;
        }

        public override XElement BuildUrlElement(IPublishedContent node, string culture)
        {
            var urlElement = base.BuildUrlElement(node, culture);

            var variants = node.Cultures.Values
                .Where(x => x.Culture.IsNullOrWhiteSpace() == false)
                .Where(x => x.Culture.InvariantEquals(culture) == false);

            foreach (var variant in variants)
            {
                var linkElement = new XElement(_xmlns + "link");

                linkElement.AddAttribute("href", node.Url(culture: variant.Culture, mode: UrlMode.Absolute));

                linkElement.AddAttribute("hreflang", variant.Culture);

                linkElement.AddAttribute("rel", "alternate");

                urlElement.Add(linkElement);
            }

            var lastModified = node.Value<DateTime?>(_config.Fields.LastModified, culture)
                ?? node.UpdateDate;

            if (lastModified > DateTime.MinValue)
            {
                urlElement.AddChild("lastmod", lastModified.ToString("yyyy-MM-dd"));
            }

            var changeFrequency = node.Value<string>(_config.Fields.ChangeFrequency, culture);

            if (string.IsNullOrWhiteSpace(changeFrequency) == false)
            {
                urlElement.AddChild("changefreq", changeFrequency.ToLower());
            }

            var priority = node.Value<decimal>(_config.Fields.Priority, culture);

            if (priority > 0)
            {
                urlElement.AddChild("priority", priority);
            }

            return urlElement;
        }

        public override IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node, string culture)
        {
            return base.GetContentItems(node, culture)
                .Where(x => x.Value<bool>(_config.Fields.Exclude) == false);
        }
    }
}