using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Composing;
using Our.Umbraco.FriendlySitemap.Configuration;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    public class SitemapComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<SitemapComponent>();

            composition.Register(factory => SitemapConfiguration.Create());

            composition.RegisterSitemap<SitemapBuilder>("sitemap.xml");
        }
    }
}