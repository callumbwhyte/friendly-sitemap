using System;

namespace Our.Umbraco.FriendlySitemap
{
    public class Constants
    {
        public const string SitemapRouteName = "Xml Sitemap";

        public const string SitemapRouteUrl = "sitemap.xml";

        public const string ConfigPrefix = "Umbraco.Sitemap.";

        public const string SitemapXmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";

        public const string SitemapXsi = "http://www.w3.org/2001/XMLSchema-instance";

        public const string SitemapSchemaLocation = SitemapXmlns + " " + SitemapXmlns + "/sitemap.xsd";
    }
}