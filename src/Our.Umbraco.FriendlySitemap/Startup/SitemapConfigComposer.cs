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

            var configuration = new SitemapConfiguration
            {
                EnableSitemap = enableSitemap
            };

            return configuration;
        }
    }
}