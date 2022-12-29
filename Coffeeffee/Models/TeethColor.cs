using System;
using System.Text.Json.Serialization;

namespace Coffeeffee.Models
{
	public class TeethColor
	{


        [JsonPropertyName("teethcolor_id")]
        public string teethcolor_id { get; set; }

        [JsonPropertyName("color")]
        public string color { get; set; }

        [JsonPropertyName("date")]
        private DateTime date { get; set; }

        [JsonPropertyName("client")]
        private Client client { get; set; }


        public TeethColor()
		{
		}
	}
}

