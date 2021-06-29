using Our.Umbraco.Extensions.Composing;
using Our.Umbraco.FriendlySitemap.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Composing
{
    internal class SitemapCollectionBuilder : LazyKeyValueCollectionBuilder<SitemapCollectionBuilder, SitemapCollection, ISitemapBuilder>
    {
        protected override Lifetime CollectionLifetime => Lifetime.Request;
    }
}