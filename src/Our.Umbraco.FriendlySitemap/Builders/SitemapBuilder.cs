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
                var buildNode = BuildNode(node);
                if(buildNode == null) continue;
                urlsetElement.Add(buildNode);
            }

            var doc = new XDocument(urlsetElement);

            return doc;
        }

        public XElement BuildNode(IPublishedContent node)
        {
            var url = node.Url(mode: UrlMode.Absolute);
            if (url.StartsWith("http") == false)
            {
                // this is an invalid url, possibly because a domain is configured without host (eg /en)
                return null;
            }
            var urlElement = new XElement(_xmlns + "url", new[]
            {
                new XElement(_xmlns + "loc", url),
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
