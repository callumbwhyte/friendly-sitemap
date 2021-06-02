using System.Web.Routing;
using Our.Umbraco.Extensions.Routing;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    internal class SitemapRouteComponent : IComponent
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILogger _logger;

        public SitemapRouteComponent(IUmbracoContextFactory umbracoContextFactory, ILogger logger)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _logger = logger;
        }

        public void Initialize()
        {
            _logger.Info<SitemapRouteComponent>("Initializing sitemap route component");


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