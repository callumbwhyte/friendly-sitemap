using System.IO;
using System.Text;

namespace Our.Umbraco.FriendlySitemap.Helpers
{
    internal class UTF8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}