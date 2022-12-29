using System;
using System.Text.Json.Serialization;

namespace Coffeeffee.Models
{
	public class Client
	{

        [JsonPropertyName("client_id")]
        public string client_id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("surname")]
        public string surname { get; set; }

        [JsonPropertyName("dentist")]
        public Dentist dentist { get; set; }


	}
}

