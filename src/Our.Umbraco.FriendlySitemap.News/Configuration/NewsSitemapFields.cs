using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.News.Configuration
{
    public class NewsSitemapFields
    {
        public string Title { get; set; } = "title";

        public string Date { get; set; } = "publicationDate";

        public string Genres { get; set; } = "genres";

        public string Keywords { get; set; } = "keywords";

        public static NewsSitemapFields Create()
        {
            var fields = new NewsSitemapFields();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Title", value => fields.Title = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Date", value => fields.Date = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Genres", value => fields.Genres = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + ".Fields.Keywords", value => fields.Keywords = value);

            return fields;
        }
    }
}