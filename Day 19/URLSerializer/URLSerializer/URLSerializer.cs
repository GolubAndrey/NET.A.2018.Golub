using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace URLSerializer
{
    public class URLSerializer : ISerializer<URL>
    {
        #region ISerializer methods

        /// <summary>
        /// Serialize list of URLs to the file at the specified path
        /// </summary>
        /// <param name="list">List of URLs</param>
        /// <param name="way">File path to write</param>
        /// <exception cref="ArgumentNullException">Thrown when one of the arguments is null</exception>
        public void Serialize(IEnumerable<URL> list, string way)
        {
            if (list==null)
            {
                throw new ArgumentNullException($"{nameof(list)} can't be null");
            }

            if (way == null)
            {
                throw new ArgumentNullException($"{nameof(way)} can't be null");
            }

            var xml = new XElement("urlAddresses",
                    list.Select(x => 
                new XElement("urlAddress",
                    new XElement("host",
                        new XAttribute("name", x.HostName)),
                    new XElement("uri", 
                        x.segments.Select(y =>
                        new XElement("segment", y))),
                    new XElement("parameters", 
                        x.parameters?.Select(y=>
                        new XElement("parameter",
                            new XAttribute("value",y.Value),
                            new XAttribute("key",y.Key)))))));
            xml.Elements("urlAddress").Where(x => x.Element("parameters").IsEmpty).AsParallel().ForAll(x => x.Element("parameters").Remove());
            XDocument xDoc = new XDocument(xml);
            xDoc.Save(way);
        }
        #endregion
    }
}
