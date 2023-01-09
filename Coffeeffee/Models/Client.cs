using System;
using System.Text.Json.Serialization;

namespace Coffeeffee.Models
{
	public class Client
	{

        [JsonPropertyName("client_id")]
        public int client_id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("surname")]
        public string surname { get; set; }

        [JsonPropertyName("dentist")]
        public string dentist { get; set; }


	}
}

