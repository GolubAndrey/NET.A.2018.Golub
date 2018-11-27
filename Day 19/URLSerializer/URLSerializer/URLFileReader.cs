using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace URLSerializer
{
    public class URLFileReader:IRepository<string>
    {
        private IEnumerable<string> elements;
        public URLFileReader(string way)
        {
            if (!File.Exists(way))
            {
                throw new FileNotFoundException($"File {nameof(way)} not found");
            }
            elements = File.ReadLines(way);
        }
        public IEnumerable<string> GetAllElements()
        {
            return elements;
        }
    }
}
