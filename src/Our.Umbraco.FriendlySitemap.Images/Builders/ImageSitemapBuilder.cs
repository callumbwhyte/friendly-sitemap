using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Extensions;
using Our.Umbraco.FriendlySitemap.Images.Configuration;
using Our.Umbraco.FriendlySitemap.Images.Persistence;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Persistence;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Images.Builders
{
    internal class ImageSitemapBuilder : SitemapBuilderBase<ImageSitemapConfiguration>
    {
        private readonly XNamespace _xmlns = XNamespace.Get("http://www.google.com/schemas/sitemap-image/1.1");

        private readonly IUmbracoContextFactory _contextFactory;
        private readonly IImageRepository _imageRepository;

        private IDictionary<int, IEnumerable<int>> _contentMap;

        public ImageSitemapBuilder(IUmbracoContextFactory contextFactory, IImageRepository imageRepository,
            ImageSitemapConfiguration config)
            : base(config)
        {
            _contextFactory = contextFactory;
            _imageRepository = imageRepository;
        }

        public override XElement BuildUrlSetElement(IPublishedContent node, CultureInfo culture)
        {
            var urlsetElement = base.BuildUrlSetElement(node, culture);

            urlsetElement.AddNamespace("image", _xmlns);

            return urlsetElement;
        }

        public override XElement BuildUrlElement(IPublishedContent node, CultureInfo culture)
        {
            if (_contentMap.TryGetValue(node.Id, out IEnumerable<int> imageIds) == false)
            {
                return null;
            }

            using (var context = _contextFactory.EnsureUmbracoContext())
            {
                var images = imageIds
                    .Select(context.UmbracoContext.Media.GetById)
                    .Where(x => x != null);

                if (images.Any() == false)
                {
                    return null;
                }

                var urlElement = new XElement(Namespace + "url");

                urlElement.AddChild("loc", node.Url(culture: culture.Name, mode: UrlMode.Absolute));

                foreach (var image in images)
                {
                    urlElement.Add(BuildMetaElement(image, culture));
                }

                return urlElement;
            }
        }

        public override XElement BuildMetaElement(IPublishedContent node, CultureInfo culture)
        {
            var imageElement = new XElement(_xmlns + "image");

            imageElement.AddChild("loc", node.Url(mode: UrlMode.Absolute));

            return imageElement;
        }

        public override IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node)
        {
            _contentMap = _imageRepository.GetDescendants(node.Id);

            using (var context = _contextFactory.EnsureUmbracoContext())
            {
                return _contentMap.Keys
                    .Select(context.UmbracoContext.Content.GetById)
                    .Where(x => x != null);
            }
        }
    }
}