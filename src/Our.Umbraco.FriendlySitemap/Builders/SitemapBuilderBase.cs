using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public abstract class SitemapBuilderBase : ISitemapBuilder
    {
        private readonly ISitemapConfiguration _config;

        public SitemapBuilderBase(ISitemapConfiguration config)
        {
            _config = config;
        }

        protected virtual XNamespace Namespace => XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

        public virtual XDocument BuildSitemap(IPublishedContent node, string culture)
        {
            if (_config.IsEnabled == false)
            {
                return null;
            }

            var nodes = GetContentItems(node, culture);

            var urlsetElement = BuildUrlSetElement(node, culture);

            urlsetElement.Add(nodes.Select(x => BuildUrlElement(x, culture)));

            var doc = new XDocument(urlsetElement);

            return doc;
        }

        public virtual XElement BuildUrlSetElement(IPublishedContent node, string culture)
        {
            return new XElement(Namespace + "urlset");
        }

        public virtual XElement BuildUrlElement(IPublishedContent node, string culture)
        {
            var urlElement = new XElement(Namespace + "url");

            urlElement.AddChild("loc", node.Url(culture: culture, mode: UrlMode.Absolute));

            var metaElement = BuildMetaElement(node, culture);

            if (metaElement != null)
            {
                urlElement.Add(metaElement);
            }

            return urlElement;
        }

        public virtual XElement BuildMetaElement(IPublishedContent node, string culture) => null;

        public virtual IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node, string culture)
        {
            return node.DescendantsOrSelf(culture)
                .Where(x => x.HasTemplate() == true);
        }
    }
}