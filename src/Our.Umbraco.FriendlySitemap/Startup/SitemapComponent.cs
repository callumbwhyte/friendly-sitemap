using System.Web.Routing;
using Our.Umbraco.Extensions.Routing;
using Our.Umbraco.FriendlySitemap.Composing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    internal class SitemapComponent : IComponent
    {
        private readonly SitemapCollection _sitemapCollection;
        private readonly IUmbracoContextFactory _contextFactory;

        public SitemapComponent(SitemapCollection sitemapCollection, IUmbracoContextFactory contextFactory)
        {
            _sitemapCollection = sitemapCollection;
            _contextFactory = contextFactory;
        }

        public void Initialize()
        {
            foreach (var path in _sitemapCollection.Keys)
            {
                var values = new
                {
                    controller = "Sitemap",
                    action = "RenderSitemap"
                };

                var routeHandler = new RootNodeByDomainRouteHandler(_contextFactory);

                RouteTable.Routes.MapUmbracoRoute(path.ToSafeAlias(), path, values, routeHandler);
            }
        }

        public void Terminate()
        {

        }
    }
}