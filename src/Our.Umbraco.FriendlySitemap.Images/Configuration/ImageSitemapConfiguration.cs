using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Images.Configuration
{
    public class ImageSitemapConfiguration : ISitemapConfiguration
    {
        public bool IsEnabled { get; set; }

        public string[] MediaTypes { get; set; } = new[] { "image" };

        public ImageSitemapFields Fields { get; set; } = ImageSitemapFields.Create();

        public static ImageSitemapConfiguration Create()
        {
            var config = new ImageSitemapConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Enable", value => config.IsEnabled = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "MediaTypes", value => config.MediaTypes = value);

            return config;
        }
    }
}