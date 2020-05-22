using System.Configuration;
using Our.Umbraco.FriendlySitemap.Configuration;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    public class SitemapConfigComposer : IUserComposer
    {
        private const string Prefix = "Umbraco.Sitemap";

        public void Compose(Composition composition)
        {
            composition.RegisterUnique(factory => GetConfiguration());
        }

        private SitemapConfiguration GetConfiguration()
        {
            bool.TryParse(ConfigurationManager.AppSettings[Prefix + ".EnableSitemap"], out bool enableSitemap);
            bool.TryParse(ConfigurationManager.AppSettings[Prefix + ".SitemapIncludeRootNode"], out bool sitemapIncludeRootNode);

            var configuration = new SitemapConfiguration
            {
                EnableSitemap = enableSitemap,
                IncludeRootNode = sitemapIncludeRootNode
            };

            return configuration;
        }
    }
}