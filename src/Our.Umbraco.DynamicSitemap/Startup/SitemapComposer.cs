using System.Configuration;
using Our.Umbraco.DynamicSitemap.Configuration;
using Umbraco.Core.Composing;

namespace Our.Umbraco.DynamicSitemap.Startup
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