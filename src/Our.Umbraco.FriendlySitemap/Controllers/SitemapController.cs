using System.Text;
using System.Web.Mvc;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Configuration;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.FriendlySitemap.Controllers
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

            var startNode = UmbracoContext.PublishedRequest.PublishedContent;

            if (startNode == null)
            {
                return HttpNotFound();
            }

            var sitemapXml = SitemapBuilder.Build(startNode);

            return Content(sitemapXml, "text/xml", Encoding.UTF8);
        }
    }
}