using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Extensions
{
    public static class PublishedContentExtensions
    {
        public static IEnumerable<IPublishedContent> DescendantsOfType(this IPublishedContent content, string[] contentTypes)
        {
            return contentTypes.SelectMany(x => content.DescendantsOfType(x));
        }

        public static bool HasTemplate(this IPublishedContent content)
        {
            return content.TemplateId.HasValue == true && content.TemplateId > 0;
        }
    }
}