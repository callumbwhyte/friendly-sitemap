using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.News.Configuration
{
    public class NewsSitemapConfiguration : ISitemapConfiguration
    {
        public bool IsEnabled { get; set; }

        public string PublicationName { get; set; }

        public string[] ContentTypes { get; set; } = new string[] { };

        public NewsSitemapFields Fields { get; set; } = NewsSitemapFields.Create();

        public static NewsSitemapConfiguration Create()
        {
            var config = new NewsSitemapConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Enable", value => config.IsEnabled = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "PublicationName", value => config.PublicationName = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "ContentTypes", value => config.ContentTypes = value);

            return config;
        }
    }
}