using System.Configuration;
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

            composition.Register(factory => GetConfiguration());
        }

        private SitemapConfiguration GetConfiguration()
        {
            bool.TryParse(ConfigurationManager.AppSettings[Constants.ConfigPrefix + "EnableSitemap"], out bool enableSitemap);
            var sitemapUrl = ConfigurationManager.AppSettings[Constants.ConfigPrefix + "SitemapUrl"];
            if (string.IsNullOrWhiteSpace(sitemapUrl))
            {
                sitemapUrl = Constants.DefaultSitemapUrl;
            }

            var configuration = new SitemapConfiguration
            {
                EnableSitemap = enableSitemap,
                SitemapUrl = sitemapUrl
            };

            return configuration;
        }
    }
}