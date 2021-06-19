using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Configuration;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    public class SitemapComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<SitemapRouteComponent>();

            composition.RegisterUnique<ISitemapBuilder, SitemapBuilder>();

            composition.Register(factory => SitemapConfiguration.Create());
        }
    }
}