using Newtonsoft.Json;
using System;

namespace XamarinAssignment.Model
{
    /// <summary>
    /// Property 
    /// </summary>
    public class Property
    {
        [JsonProperty("listingID")]
        public int ListingID { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("beds")]
        public int Beds { get; set; }
        [JsonProperty("baths")]
        public int Baths { get; set; }
    }
}

