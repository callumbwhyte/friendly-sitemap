using System;
using System.Configuration;

namespace Our.Umbraco.FriendlySitemap.Helpers
{
    public static class ConfigurationHelper
    {
        public static void SetProperty(string key, Action<string> setValue)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                setValue(value);
            }
        }

        public static void SetProperty(string key, Action<string[]> setValue, char separator = ',')
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value) == false)
            {
                setValue(value.Split(separator));
            }
        }

        public static void SetProperty(string key, Action<bool> setValue)
        {
            bool.TryParse(ConfigurationManager.AppSettings[key], out bool property);

            setValue(property);
        }

        
    }
}