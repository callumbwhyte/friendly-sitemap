using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.Sitemap.Startup
{
    public class RouteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Insert<RouteComponet>();
        }
    }
}