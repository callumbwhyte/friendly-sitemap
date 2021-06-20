using Our.Umbraco.FriendlySitemap.Composing;
using Our.Umbraco.FriendlySitemap.News.Builders;
using Our.Umbraco.FriendlySitemap.News.Configuration;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.News.Startup
{
    public class NewsSitemapComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register(factory => NewsSitemapConfiguration.Create());

            composition.RegisterSitemap<NewsSitemapBuilder>("sitemap_news.xml");
        }
    }
}