using Our.Umbraco.FriendlySitemap.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Composing
{
    public static class CompositionExtensions
    {
        public static void RegisterSitemap<T>(this Composition composition, string path)
            where T : ISitemapBuilder
        {
            composition.WithCollectionBuilder<SitemapCollectionBuilder>()
                .Add<T>(path);
        }

        public static void RemoveSitemap(this Composition composition, string path)
        {
            composition.WithCollectionBuilder<SitemapCollectionBuilder>()
                .Remove(path);
        }
    }
}