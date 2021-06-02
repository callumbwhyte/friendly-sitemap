using System.Text;
using System.Web.Mvc;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Configuration;
using Our.Umbraco.FriendlySitemap.Helpers;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.FriendlySitemap.Controllers
{
    public class SitemapController : RenderMvcController
    {
        private readonly SitemapConfiguration _sitemapConfig;
        private readonly ISitemapBuilder _sitemapBuilder;
        private readonly ILogger _logger;

        public SitemapController(SitemapConfiguration sitemapConfig, ISitemapBuilder sitemapBuilder, ILogger logger)
        {
            _sitemapConfig = sitemapConfig;
            _sitemapBuilder = sitemapBuilder;
            _logger = logger;
        }

        public ActionResult RenderSitemap()
        {
            if (_sitemapConfig.EnableSitemap == false)
            {
                _logger.Warn<SitemapController>("sitemap is not enabled in configuration");
                return HttpNotFound();
            }

            var startNode = UmbracoContext.PublishedRequest.PublishedContent;

            if (startNode == null)
            {
                return HttpNotFound();
            }

            using (var writer = new UTF8StringWriter())
            {
                var doc = _sitemapBuilder.BuildSitemap(startNode);

                doc.Save(writer);

                var sitemapXml = writer.ToString();

                return Content(sitemapXml, "text/xml", Encoding.UTF8);
            }
        }
    }
}