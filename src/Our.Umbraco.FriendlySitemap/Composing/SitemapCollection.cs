using System;
using System.Collections.Generic;
using Our.Umbraco.Extensions.Composing;
using Our.Umbraco.FriendlySitemap.Builders;

namespace Our.Umbraco.FriendlySitemap.Composing
{
    public class SitemapCollection : LazyKeyValueCollection<ISitemapBuilder>
    {
        private IDictionary<string, Lazy<ISitemapBuilder>> _collection;

        public SitemapCollection(IDictionary<string, Lazy<ISitemapBuilder>> collection)
            : base(collection)
        {
            _collection = collection;
        }

        public IEnumerable<string> Paths => _collection.Keys;
    }
}