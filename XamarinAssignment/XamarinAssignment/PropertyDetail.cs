using Newtonsoft.Json;
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
    public class PropertyDetail : Property
    {
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
