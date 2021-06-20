using Our.Umbraco.FriendlySitemap.Configuration;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public class SitemapBuilderBase<T> : SitemapBuilderBase
        where T : ISitemapConfiguration
    {
        public SitemapBuilderBase(T config)
            : base(config)
        {

        }
    }
}