using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace Our.Umbraco.FriendlySitemap.Helpers
{
    internal static class DomainHelper
    {
        public static Domain GetDomainByUri(UmbracoContext umbracoContext, Uri uri)
        {
            var baseDomains = GetDomainsByUri(umbracoContext, uri);

            return baseDomains.FirstOrDefault();
        }

        public static IEnumerable<Domain> GetDomainsByUri(UmbracoContext umbracoContext, Uri uri)
        {
            var domains = umbracoContext.Domains.GetAll(false);

            var domainsAndUris = domains.Select(x => new DomainAndUri(x, uri));

            if (domainsAndUris.Any() == false)
            {
                return null;
            }

            var uriWithSlash = uri.EndPathWithSlash();

            var baseDomains = GetBaseDomains(domainsAndUris, uriWithSlash);

            if (baseDomains.Any() == false)
            {
                baseDomains = GetBaseDomains(domainsAndUris, uriWithSlash.WithoutPort());
            }

            return baseDomains;
        }

        private static IEnumerable<DomainAndUri> GetBaseDomains(IEnumerable<DomainAndUri> domainsAndUris, Uri uri)
        {
            return domainsAndUris.Where(x => x.Uri.EndPathWithSlash().IsBaseOf(uri) == true);
        }

        public static IPublishedContent GetContentByDomain(UmbracoContext umbracoContext, Domain domain)
        {
            if (domain.ContentId < 1)
            {
                return null;
            }

            var content = umbracoContext.Content.GetById(domain.ContentId);

            return content;
        }
    }
}