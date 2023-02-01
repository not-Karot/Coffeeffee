using System;
using System.IO;
using System.Text.Json.Serialization;

namespace WhiteTeeth.Models
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

        [JsonPropertyName("image")]
        public string image { get; set; }

    }
}

