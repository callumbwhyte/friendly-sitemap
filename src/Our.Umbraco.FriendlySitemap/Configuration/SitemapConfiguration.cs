using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Configuration
{
    public class SitemapConfiguration
    {
        public bool IsEnabled { get; set; }

        public SitemapFields Fields { get; set; } = SitemapFields.Create();

        public static SitemapConfiguration Create()
        {
            var config = new SitemapConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Enable", value => config.IsEnabled = value);

            return config;
        }
    }
}