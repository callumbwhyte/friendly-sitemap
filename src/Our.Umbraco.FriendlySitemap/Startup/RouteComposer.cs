using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Startup
{
    public class RouteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Insert<RouteComponet>();
        }
    }
}