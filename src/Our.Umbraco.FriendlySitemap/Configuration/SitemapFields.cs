using Our.Umbraco.FriendlySitemap.Helpers;

namespace Our.Umbraco.FriendlySitemap.Configuration
{
    public class SitemapFields
    {
        public string Exclude { get; set; } = "sitemapExclude";

        public string LastModified { get; set; } = "sitemapLastMod";

        public string ChangeFrequency { get; set; } = "sitemapChangeFreq";

        public string Priority { get; set; } = "sitemapPriority";

        public static SitemapFields Create()
        {
            var fields = new SitemapFields();

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.Exclude", value => fields.Exclude = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.LastModified", value => fields.LastModified = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.ChangeFrequency", value => fields.ChangeFrequency = value);

            ConfigurationHelper.SetProperty(Constants.ConfigPrefix + "Fields.Priority", value => fields.Priority = value);

            return fields;
        }
    }
}