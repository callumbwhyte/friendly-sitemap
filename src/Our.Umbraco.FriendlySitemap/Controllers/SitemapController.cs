using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Our.Umbraco.FriendlySitemap.Builders;
using Our.Umbraco.FriendlySitemap.Composing;
using Our.Umbraco.FriendlySitemap.Helpers;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.FriendlySitemap.Controllers
{
    public class SitemapController : RenderMvcController
    {
        private readonly SitemapCollection _sitemapCollection;

        public SitemapController(SitemapCollection sitemapCollection)
        {
            _sitemapCollection = sitemapCollection;
        }

        public ActionResult RenderSitemap()
        {
            var route = ((Route)RouteData.Route).Url;

            if (_sitemapCollection.TryGetValue(route, out ISitemapBuilder builder) == false)
            {
                return HttpNotFound();
            }

            var request = UmbracoContext.PublishedRequest;

            var startNode = request?.PublishedContent;

            if (startNode == null)
            {
                return HttpNotFound();
            }

            var culture = request?.Culture;

            if (culture == null)
            {
                return HttpNotFound();
            }

            var doc = builder.BuildSitemap(startNode, culture);

            if (doc == null)
            {
                return HttpNotFound();
            }

            using (var writer = new UTF8StringWriter())
            {
                doc.Save(writer);

                var sitemapXml = writer.ToString();

                return Content(sitemapXml, "text/xml", Encoding.UTF8);
            }
        }
    }
}