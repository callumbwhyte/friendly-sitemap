using System.Web.Routing;
using Our.Umbraco.DynamicSitemap.Helpers;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.DynamicSitemap.Routing
{
    internal class RootNodeByDomainRouteHandler : UmbracoVirtualNodeRouteHandler
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RootNodeByDomainRouteHandler(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        protected override IPublishedContent FindContent(RequestContext requestContext, UmbracoContext umbracoContext)
        {
            var requestUri = requestContext.HttpContext.Request.Url;

            var domain = DomainHelper.GetDomainByUri(umbracoContext, requestUri);

            if (domain == null)
            {
                return null;
            }

            var content = DomainHelper.GetContentByDomain(umbracoContext, domain);

            if (content == null)
            {
                return content;
            }

            return content;
        }

        protected override UmbracoContext GetUmbracoContext(RequestContext requestContext)
        {
            var umbracoContext = base.GetUmbracoContext(requestContext);

            if (umbracoContext == null)
            {
                var contextReference = _umbracoContextFactory.EnsureUmbracoContext(requestContext.HttpContext);

                return contextReference.UmbracoContext;
            }

            return umbracoContext;
        }
    }
}