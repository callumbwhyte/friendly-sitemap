using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Images.Configuration
{
    public class ImageSitemapConfiguration : ISitemapConfiguration
    {
        public bool IsEnabled { get; set; }

        public static ImageSitemapConfiguration Create()
        {
            var config = new ImageSitemapConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Enable", value => config.IsEnabled = value);

            return config;
        }
    }
}