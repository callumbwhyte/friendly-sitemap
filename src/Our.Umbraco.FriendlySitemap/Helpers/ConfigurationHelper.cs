using System;
using System.Configuration;

namespace Our.Umbraco.FriendlySitemap.Helpers
{
    public static class ConfigurationHelper
    {
        public static void SetProperty(string key, Action<bool> setValue)
        {
            bool.TryParse(ConfigurationManager.AppSettings[key], out bool property);

            setValue(property);
        }
    }
}