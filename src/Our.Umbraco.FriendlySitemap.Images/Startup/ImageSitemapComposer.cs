using Our.Umbraco.FriendlySitemap.Composing;
using Our.Umbraco.FriendlySitemap.Images.Builders;
using Our.Umbraco.FriendlySitemap.Images.Configuration;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Images.Startup
{
    public class ImageSitemapComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register(factory => ImageSitemapConfiguration.Create());

            composition.RegisterSitemap<ImageSitemapBuilder>("sitemap_images.xml");
        }
    }
}