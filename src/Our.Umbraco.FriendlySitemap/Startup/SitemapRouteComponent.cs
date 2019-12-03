using System.Web.Routing;
using Our.Umbraco.Extensions.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    internal class SitemapRouteComponent : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SitemapRouteComponent(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public void Initialize()
        {
            RouteTable.Routes.MapUmbracoRoute(
                Constants.SitemapRouteName,
                Constants.SitemapRouteUrl,
                new
                {
                    controller = "Sitemap",
                    action = "RenderSitemap"
                },
                new RootNodeByDomainRouteHandler(_umbracoContextFactory)
            );
        }

        public void Terminate()
        {

        }
    }
}