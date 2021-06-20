using System.Collections.Generic;
using System.Globalization;
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

        public virtual XDocument BuildSitemap(IPublishedContent node, CultureInfo culture)
        {
            if (_config.IsEnabled == false)
            {
                return null;
            }

            var nodes = GetContentItems(node);

            var urlsetElement = BuildUrlSetElement(node, culture);

            urlsetElement.Add(nodes.Select(x => BuildUrlElement(x, culture)));

            var doc = new XDocument(urlsetElement);

            return doc;
        }

        public virtual XElement BuildUrlSetElement(IPublishedContent node, CultureInfo culture)
        {
            return new XElement(Namespace + "urlset");
        }

        public abstract XElement BuildUrlElement(IPublishedContent node, CultureInfo culture);

        public virtual IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node)
        {
            return node
                .DescendantsOrSelf()
                .Where(x => x.HasTemplate() == true);
        }
    }
}