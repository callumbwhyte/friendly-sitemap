using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Our.Umbraco.FriendlySitemap.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.FriendlySitemap.Builders
{
    public static class SitemapBuilder
    {
        private static readonly XNamespace _xmlns = XNamespace.Get(Constants.SitemapXmlns);

        public static string Build(IPublishedContent startNode)
        {
            var nodes = BuildSitemapNodes(startNode);
            var xmlElement = BuildXmlElement();

            var sitemapXmlString = new StringWriterExtensions(new UTF8Encoding());
            var xmlDeclaration = new XDeclaration("1.0", Encoding.UTF8.BodyName, "yes");

            foreach (var node in nodes)
            {
                var urlElement = new XElement(_xmlns +"url", 
                    new XElement(_xmlns + "loc", node.Url(mode: UrlMode.Absolute)), 
                    new XElement(_xmlns + "lastmod", node.UpdateDate.ToString("yyyy-MM-dd")));

                var changeFreqency = node.Value<string>("sitemapChangeFreq");

                if (string.IsNullOrWhiteSpace(changeFreqency) == false)
                {
                    urlElement.Add(new XElement(_xmlns + "changefreq", changeFreqency.ToLower()));
                }

                var priority = node.Value<decimal>("sitemapPriority");

                if (priority > 0)
                {
                    urlElement.Add(new XElement(_xmlns + "priority", priority));
                }

                xmlElement.Add(urlElement);
            }

            var sitemapXml = new XDocument(xmlDeclaration, xmlElement);

            sitemapXml.Save(sitemapXmlString);

            return sitemapXmlString.ToString();
        }

        public static IEnumerable<IPublishedContent> BuildSitemapNodes(IPublishedContent startNode)
        {
            return startNode
                .DescendantsOrSelf()
                .Where(x => x.HasTemplate())
                .Where(x => x.IncludedInSitemap());
        }

        private static XElement BuildXmlElement()
        {
            var xsi = XNamespace.Get(Constants.SitemapXsi);
            var schemaLocation = XNamespace.Get(Constants.SitemapSchemaLocation);

            var xmlElement =
                new XElement(_xmlns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                    new XAttribute(xsi + "schemaLocation", schemaLocation));

            return xmlElement;
        }
    }
}
