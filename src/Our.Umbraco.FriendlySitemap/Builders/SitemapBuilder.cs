using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public class SitemapBuilder : ISitemapBuilder
    {
        private readonly XNamespace _xmlns = XNamespace.Get("https://www.sitemaps.org/schemas/sitemap/0.9");

        public XDocument BuildSitemap(IPublishedContent startNode)
        {
            var nodes = startNode
                .DescendantsOrSelf()
                .Where(x => x.HasTemplate() == true)
                .Where(x => x.Value<bool>("sitemapExclude") == false);

            var urlsetElement = new XElement(_xmlns + "urlset");

            foreach (var node in nodes)
            {
                urlsetElement.Add(BuildNode(node));
            }

            var doc = new XDocument(urlsetElement);

            return doc;
        }

        public XElement BuildNode(IPublishedContent node)
        {
            var urlElement = new XElement(_xmlns + "url", new[]
            {
                new XElement(_xmlns + "loc", node.Url(mode: UrlMode.Absolute)),
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
    }
}
