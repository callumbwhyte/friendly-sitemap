using System.Web.Routing;
using Our.Umbraco.Sitemap.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.Sitemap.Startup
{
    internal class RouteComponet : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RouteComponet(IUmbracoContextFactory umbracoContextFactory)
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