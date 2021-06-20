using System;
using System.Xml.Linq;

namespace Our.Umbraco.FriendlySitemap.Extensions
{
    public static class XmlExtensions
    {
        public static XElement AddAttribute(this XElement element, XName name, object value)
        {
            var attribute = new XAttribute(name, value);

            element.Add(attribute);

            return element;
        }

        public static XElement AddChild(this XElement element, string name, params object[] content)
        {
            var child = new XElement(element.Name.Namespace + name, content);

            element.Add(child);

            return element;
        }

        public static XElement AddChild(this XElement element, string name, Func<XElement, object> func)
        {
            var child = new XElement(element.Name.Namespace + name);

            func(child);

            element.Add(child);

            return element;
        }

        public static XElement AddNamespace(this XElement element, string alias, XNamespace ns)
        {
            element.AddAttribute(XNamespace.Xmlns + alias, ns);

            return element;
        }
    }
}