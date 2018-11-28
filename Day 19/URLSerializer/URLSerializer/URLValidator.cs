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
        public bool Validate(string element)
        {
            if (element==null)
            {
                return false;
            }

            try
            {
                new Uri(element);
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
