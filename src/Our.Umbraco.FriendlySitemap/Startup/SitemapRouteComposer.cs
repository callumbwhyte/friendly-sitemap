using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    public class SitemapRouteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Insert<SitemapRouteComponent>();
        }
    }
}