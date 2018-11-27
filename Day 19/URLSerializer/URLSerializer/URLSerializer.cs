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
    public class URLSerializer:ISerializer<URL>
    {
        public void Serialize(IEnumerable<URL> list,string way)
        {
            var xml = new XElement("urlAddresses", 
                list.Select(x => new XElement("urlAddress",
                new XElement("host",
                new XAttribute("name",x.HostName)),
                new XElement("uri",x.segments.Select(y=>
                new XElement("segment",y))),
                new XElement("parameters",x.parameters?.Select(y=>
                new XElement("parameter",
                new XAttribute("value",y.Value),
                new XAttribute("key",y.Key)))))));
            XDocument xDoc = new XDocument(xml);
            xDoc.Save(way);
        }
    }
}
