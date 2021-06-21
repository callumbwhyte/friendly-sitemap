using System.Globalization;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Extensions;
using Our.Umbraco.FriendlySitemap.Images.Configuration;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.FriendlySitemap.Images.Builders
{
    internal class ImageSitemapBuilder : SitemapBuilderBase<ImageSitemapConfiguration>
    {
        private readonly XNamespace _xmlns = XNamespace.Get("http://www.google.com/schemas/sitemap-image/1.1");

        public ImageSitemapBuilder(ImageSitemapConfiguration config)
            : base(config)
        {

        }

        public override XElement BuildUrlSetElement(IPublishedContent node, CultureInfo culture)
        {
            var urlsetElement = base.BuildUrlSetElement(node, culture);

            urlsetElement.AddNamespace("image", _xmlns);

            return urlsetElement;
        }
    }
}