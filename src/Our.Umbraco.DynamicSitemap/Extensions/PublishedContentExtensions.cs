using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.DynamicSitemap.Extensions
{
    public static class PublishedContentExtensions
    {
        public static bool HasTemplate(this IPublishedContent content)
        {
            return content.TemplateId.HasValue == true;
        }
    }
}