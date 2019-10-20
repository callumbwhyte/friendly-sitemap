using System.Text;
using System.Web.Mvc;
using Our.Umbraco.Sitemap.Configuration;
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

            return Content("", "text/xml", Encoding.UTF8);
        }
    }
}