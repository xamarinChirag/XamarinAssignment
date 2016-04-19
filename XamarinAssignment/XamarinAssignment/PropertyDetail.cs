using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAssignment.Model
{
    /// <summary>
    /// PropertyDetail
    /// </summary>

    [Table("PropertyDetail")]
    public class PropertyDetail 
    {
        [JsonProperty("listingID")]
        [PrimaryKey, AutoIncrement]
        public int ListingID { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("beds")]
        public int Beds { get; set; }
        [JsonProperty("baths")]
        public int Baths { get; set; }
        [JsonProperty("features")]
        public string Features { get; set; }
        [JsonProperty("estimatedValue")]
        public int EstimatedValue { get; set; }
        [JsonProperty("changeOverLastYear")]
        public double ChangeOverLastYear { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
