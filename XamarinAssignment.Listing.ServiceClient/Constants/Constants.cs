using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAssignment.ServiceClient
{
    /// <summary>
    /// Costant fields for configuration
    /// </summary>
    public static  class Constants
    {
        #region Fields
        /// <summary>
        /// Rest URL for the Webservice
        /// </summary>
        public static string strRestUrl = "https://sample-listings.herokuapp.com";

        /// <summary>
        /// Listing the proeprty section
        /// </summary>
        public static string strListing = "/listings";

        /// <summary>
        /// Property details listing section
        /// </summary>
        public static string strListingById = "/listings/{0}";

        /// <summary>
        /// Getting the image url section
        /// </summary>
        public static string strImage = "/images/{0}";

        #endregion
    }
}
