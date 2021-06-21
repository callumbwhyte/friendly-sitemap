using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Images.Configuration
{
    public class ImageSitemapFields
    {
        public string Title { get; set; } = "title";

        public string Caption { get; set; } = "caption";

        public string GeoLocation { get; set; } = "geoLocation";

        public string License { get; set; } = "license";

        public static ImageSitemapFields Create()
        {
            var fields = new ImageSitemapFields();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.Title", value => fields.Title = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.Caption", value => fields.Caption = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.GeoLocation", value => fields.GeoLocation = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.License", value => fields.License = value);

            return fields;
        }
    }
}