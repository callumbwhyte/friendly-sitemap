using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.FriendlySitemap.Builders;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Composing
{
    internal class SitemapCollectionBuilder : CollectionBuilderBase<SitemapCollectionBuilder, SitemapCollection, ISitemapBuilder>
    {
        private readonly IDictionary<string, Type> _paths;

        public SitemapCollectionBuilder()
        {
            _paths = new Dictionary<string, Type>();
        }

        public void Add<T>(string path)
            where T : ISitemapBuilder
        {
            _paths[path] = typeof(T);

            Configure(types => types.Add(typeof(T)));
        }

        public void Remove(string path)
        {
            _paths.Remove(path);
        }

        protected override Lifetime CollectionLifetime => Lifetime.Request;

        public override SitemapCollection CreateCollection(IFactory factory)
        {
            var collection = _paths.ToDictionary(x => x.Key, x => CreateItem(factory, x.Value));

            return factory.CreateInstance<SitemapCollection>(collection);
        }
    }
}