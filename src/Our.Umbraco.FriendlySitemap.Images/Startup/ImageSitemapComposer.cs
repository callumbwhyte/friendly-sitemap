using Our.Umbraco.FriendlySitemap.Composing;
using Our.Umbraco.FriendlySitemap.Images.Builders;
using Our.Umbraco.FriendlySitemap.Images.Configuration;
using Our.Umbraco.FriendlySitemap.Images.Persistence;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.FriendlySitemap.Images.Startup
{
    public class ImageSitemapComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.RegisterUnique<IImageRepository, ImageRepository>();

            composition.Register(factory => ImageSitemapConfiguration.Create());

            composition.RegisterSitemap<ImageSitemapBuilder>("sitemap_images.xml");
        }
    }
}