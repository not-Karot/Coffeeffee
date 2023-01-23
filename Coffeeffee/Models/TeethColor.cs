using System;
using System.Text.Json.Serialization;

namespace Coffeeffee.Models
{
	public class TeethColor
	{


        [JsonPropertyName("teethcolor_id")]
        public int teethcolor_id { get; set; }

        [JsonPropertyName("color")]
        public string color { get; set; }

        [JsonPropertyName("date")]
        public DateTime date { get; set; }

        [JsonPropertyName("client")]
        public string client { get; set; }

        [JsonPropertyName("image")]
        public string image { get; set; }

        public TeethColor()
		{
		}
	}
}

