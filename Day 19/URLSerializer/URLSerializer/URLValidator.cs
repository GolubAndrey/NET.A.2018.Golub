using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    public class URLValidator:IValidator<string,URL>
    {
        #region IValidator's methods
        /// <summary>
        /// Validate input enumeration
        /// </summary>
        /// <param name="list">String enumeration</param>
        /// <returns>True if input data correct, otherwise false</returns>
        public bool Validate(IEnumerable<string> list)
        {
            if (list==null)
            {
                return false;
            }

            try
            {
                //list.AsParallel().ForAll(x => new Uri(x));????????????????????????
                foreach(string element in list)
                {
                    new Uri(element);
                }
            }
            catch(UriFormatException ex)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
