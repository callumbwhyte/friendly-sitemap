using System.Xml.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public interface ISitemapBuilder
    {
        XDocument BuildSitemap(IPublishedContent startNode);
    }
}