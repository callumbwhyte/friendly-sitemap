using System.Configuration;
using Our.Umbraco.Sitemap.Configuration;
using Umbraco.Core.Composing;

namespace Our.Umbraco.Sitemap.Startup
{
    public class SitemapComposer : IComposer
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