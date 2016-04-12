using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAssignment.ServiceClient
{
    public static  class Constants
    {
        public static string strRestUrl = "https://sample-listings.herokuapp.com";
        public static string strListing = "/listings";
        public static string strListingById = "/listings/{0}";
        public static string strImage = "/images/{0}";
    }
}
