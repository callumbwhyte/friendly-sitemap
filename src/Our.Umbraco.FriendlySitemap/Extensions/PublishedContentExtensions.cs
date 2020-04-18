using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Extensions
{
    public static class PublishedContentExtensions
    {
        public static bool HasTemplate(this IPublishedContent content)
        {
            return content.TemplateId.HasValue == true;
        }

        public static bool IncludedInSitemap(this IPublishedContent content)
        {
            return content.Value<bool>("sitemapExclude") == false;
        }
    }
}