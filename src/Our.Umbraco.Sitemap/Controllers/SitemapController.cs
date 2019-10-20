using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using Our.Umbraco.Sitemap.Configuration;
using Our.Umbraco.Sitemap.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.Sitemap.Controllers
{
    public class SitemapController : RenderMvcController
    {
        private readonly SitemapConfiguration _sitemapConfig;

        public SitemapController(SitemapConfiguration sitemapConfig)
        {
            _sitemapConfig = sitemapConfig;
        }

        public ActionResult RenderSitemap()
        {
            if (_sitemapConfig.EnableSitemap == false)
            {
                return HttpNotFound();
            }

            var sitemapXml = BuildSitemap();

            return Content(sitemapXml, "text/xml", Encoding.UTF8);
        }

        private string BuildSitemap()
        {
            var startNode = UmbracoContext.PublishedRequest.PublishedContent;

            var nodes = startNode
                .Descendants()
                .Where(x => x.IsVisible() == true && x.HasTemplate() == true);

            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (var node in nodes)
            {
                var urlElement = new XElement("url", new[]
                {
                    new XElement("loc", node.Url(mode: UrlMode.Absolute)),
                    new XElement("lastmod", node.UpdateDate.ToString("yyyy-MM-dd"))
                });

                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);

            var sitemapXml = document.ToString();

            return sitemapXml;
        }
    }
}