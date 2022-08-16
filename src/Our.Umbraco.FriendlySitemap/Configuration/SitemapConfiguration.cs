using System.Collections.Generic;
using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Configuration
{
    public class SitemapConfiguration : ISitemapConfiguration
    {
        public bool IsEnabled { get; set; }
        public  string[] ExcludeList { get; set; }

        public SitemapFields Fields { get; set; } = SitemapFields.Create();

        public static SitemapConfiguration Create()
        {
            var config = new SitemapConfiguration();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Enable", value => config.IsEnabled = value);
            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Exclude",  value =>config.ExcludeList = value,',');
            return config;
        }
    }
}