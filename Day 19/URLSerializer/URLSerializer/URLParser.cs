using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    public class URLParser:IConverter<string,URL>
    {
        #region IConverter methods
        /// <summary>
        /// Convert list of strings to list of URLs
        /// </summary>
        /// <param name="urls">List of strings</param>
        /// <exception cref="ArgumentNullException">Thrown when enumeration is null</exception>
        /// <returns>List of URLs</returns>
        public IEnumerable<URL> Convert(IEnumerable<string> urls)
        {
            if (urls == null)
            {
                throw new ArgumentNullException($"{nameof(urls)} can't be null");
            }
            foreach (string url in urls)
            {
                yield return TakeURL(url);
            }
        }
        #endregion

        #region private methods
        private URL TakeURL(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException($"{nameof(url)} can't be null");
            }
            Uri uri = new Uri(url);
            return new URL(uri.Host,GetSegments(uri.Segments),GetParameters(uri.Query));
        }


        private IEnumerable<string> GetSegments(string[] segments)
        {
            if (segments == null)
            {
                throw new ArgumentNullException($"{nameof(segments)} can't be null");
            }
            if (segments.Length==1)
            {
                return null;
            }
            List<string> resultList = new List<string>();
            for (int i=1;i<segments.Length;i++)
            {
                if (i==segments.Length)
                {
                    resultList.Add(segments[i]);
                    continue;
                }
                resultList.Add(segments[i].Substring(0, segments[i].Length - 1));
            }
            return resultList;
        }

        private Dictionary<string,string> GetParameters(string parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException($"{nameof(parameters)} can't be null");
            }
            if (parameters == "")
            {
                return null;
            }
            Dictionary<string, string> result = new Dictionary<string, string>();
            string resultString = parameters.Substring(1, parameters.Length - 1);
            string[] query = resultString.Split('&');
            for (int i=0;i<query.Length;i++)
            {
                string[] parameter = query[i].Split('=');
                result.Add(parameter[0], parameter[1]);
            }
            return result;
        }
        #endregion
    }
}
