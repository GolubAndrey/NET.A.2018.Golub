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
        #region private fields
        private IEnumerable<string> elements;
        #endregion

        #region Constructors
        /// <summary>
        /// URL file reader constructor
        /// </summary>
        /// <param name="way">Way of URL's file</param>
        /// <exception cref="FileNotFoundException">Thrown when there is no file in this path</exception>
        public URLFileReader(string way)
        {
            if (!File.Exists(way))
            {
                throw new FileNotFoundException($"File {nameof(way)} not found");
            }
            elements = File.ReadLines(way);
        }
        #endregion

        #region IRepository methods
        /// <summary>
        /// Get all lines from file
        /// </summary>
        /// <returns>List of URL's lines</returns>
        public IEnumerable<string> GetAllElements()
        {
            return elements;
        }
        #endregion
    }
}
