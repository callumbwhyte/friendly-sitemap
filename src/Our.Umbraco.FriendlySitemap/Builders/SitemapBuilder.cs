using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public class SitemapBuilder : ISitemapBuilder
    {
        private readonly XNamespace _xmlns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

        public XDocument BuildSitemap(IPublishedContent startNode, CultureInfo culture)
        {
            var nodes = GetContentItems(startNode);

            var urlsetElement = new XElement(_xmlns + "urlset");

            urlsetElement.Add(nodes.Select(x => BuildNode(x, culture)));

            var doc = new XDocument(urlsetElement);

            return doc;
        }

        public XElement BuildNode(IPublishedContent node, CultureInfo culture)
        {
            var urlElement = new XElement(_xmlns + "url", new[]
            {
                new XElement(_xmlns + "loc", node.Url(culture: culture.Name, mode: UrlMode.Absolute)),
                new XElement(_xmlns + "lastmod", node.UpdateDate.ToString("yyyy-MM-dd"))
            });

            var changeFrequency = node.Value<string>("sitemapChangeFreq");

            if (string.IsNullOrWhiteSpace(changeFrequency) == false)
            {
                urlElement.Add(new XElement(_xmlns + "changefreq", changeFrequency.ToLower()));
            }

            var priority = node.Value<decimal>("sitemapPriority");

            if (priority > 0)
            {
                urlElement.Add(new XElement(_xmlns + "priority", priority));
            }

            return urlElement;
        }

        public virtual IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node)
        {
            return node
                .DescendantsOrSelf()
                .Where(x => x.HasTemplate() == true)
                .Where(x => x.Value<bool>("sitemapExclude") == false);
        }
    }
}