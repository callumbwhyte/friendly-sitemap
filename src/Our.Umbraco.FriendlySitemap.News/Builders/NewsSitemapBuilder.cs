using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Extensions;
using Our.Umbraco.FriendlySitemap.News.Configuration;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.News.Builders
{
    public class NewsSitemapBuilder : SitemapBuilderBase<NewsSitemapConfiguration>
    {
        private readonly XNamespace _xmlns = XNamespace.Get("http://www.google.com/schemas/sitemap-news/0.9");

        private readonly NewsSitemapConfiguration _config;

        public NewsSitemapBuilder(NewsSitemapConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public override XElement BuildUrlSetElement(IPublishedContent node, string culture)
        {
            var urlsetElement = base.BuildUrlSetElement(node, culture);

            urlsetElement.AddNamespace("news", _xmlns);

            return urlsetElement;
        }

        public override XElement BuildMetaElement(IPublishedContent node, string culture)
        {
            var newsElement = new XElement(_xmlns + "news");

            var title = node.Value<string>(_config.Fields.Title, culture)
                ?? node.Name(culture);

            if (string.IsNullOrWhiteSpace(title) == false)
            {
                newsElement.AddChild("title", title);
            }

            var cultureInfo = new CultureInfo(culture);

            newsElement.AddChild("publication", x => x
                .AddChild("name", _config.PublicationName)
                .AddChild("language", cultureInfo.TwoLetterISOLanguageName)
            );

            var publicationDate = node.Value<DateTime?>(_config.Fields.Date, culture)
                ?? node.CreateDate;

            if (publicationDate > DateTime.MinValue)
            {
                newsElement.AddChild("publication_date", publicationDate.ToString("yyyy-MM-dd hh:mm:ss"));
            }

            var genres = node.Value<IEnumerable<string>>(_config.Fields.Genres, culture);

            if (genres != null && genres.Any() == true)
            {
                newsElement.AddChild("genres", string.Join(",", genres));
            }

            var keywords = node.Value<IEnumerable<string>>(_config.Fields.Keywords, culture);

            if (keywords != null && keywords.Any() == true)
            {
                newsElement.AddChild("keywords", string.Join(",", keywords));
            }

            return newsElement;
        }

        public override IEnumerable<IPublishedContent> GetContentItems(IPublishedContent node, string culture)
        {
            return node.DescendantsOfType(_config.ContentTypes, culture)
                .Where(x => x.HasTemplate() == true);
        }
    }
}