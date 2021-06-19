using System.Collections.Generic;
using Our.Umbraco.FriendlySitemap.Builders;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Composing
{
    public class SitemapCollection : Dictionary<string, ISitemapBuilder>, IBuilderCollection<ISitemapBuilder>
    {
        public SitemapCollection(IDictionary<string, ISitemapBuilder> collection)
            : base(collection)
        {

        }

        IEnumerator<ISitemapBuilder> IEnumerable<ISitemapBuilder>.GetEnumerator()
            => this.Values.GetEnumerator();
    }
}