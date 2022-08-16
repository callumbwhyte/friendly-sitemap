using System;

namespace Our.Umbraco.FriendlySitemap.Configuration
{
    public interface ISitemapConfiguration
    {
        bool IsEnabled { get; }
        string[] ExcludeList { get; }
    }
}