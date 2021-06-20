using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.News.Configuration
{
    public class NewsSitemapFields
    {
        public string Title { get; set; } = "title";

        public string Date { get; set; } = "publicationDate";

        public static NewsSitemapFields Create()
        {
            var fields = new NewsSitemapFields();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Title", value => fields.Title = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Date", value => fields.Date = value);

            return fields;
        }
    }
}