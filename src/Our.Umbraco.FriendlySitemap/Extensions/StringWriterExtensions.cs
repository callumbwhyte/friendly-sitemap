using System.IO;
using System.Text;

namespace Our.Umbraco.FriendlySitemap.Extensions
{
    public class StringWriterExtensions : StringWriter
    {
        public override Encoding Encoding { get; }

        public StringWriterExtensions(Encoding encodingType)
        {
            this.Encoding = encodingType;
        }
    }
}