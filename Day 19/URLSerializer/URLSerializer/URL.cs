using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace URLSerializer
{
    
    public class URL
    {
        public string HostName { get; private set; }
        public List<string> segments { get; private set; }

        public Dictionary<string,string> parameters { get; private set; }

        public URL(string hostName,IEnumerable<string> segments,Dictionary<string,string> parameters)
        {
            this.HostName = hostName;
            this.segments = segments.ToList();
            this.parameters = parameters;
        }
    }
}
