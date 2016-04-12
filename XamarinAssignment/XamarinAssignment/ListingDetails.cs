using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAssignment.Model
{
    public class ListingDetail
    {
        public int listingID { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public int beds { get; set; }
        public int baths { get; set; }
        public string features { get; set; }
        public int estimatedValue { get; set; }
        public double changeOverLastYear { get; set; }
        public string link { get; set; }
    }
}
