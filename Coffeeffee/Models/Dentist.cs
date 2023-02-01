using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Coffeeffee.Models
{
    public class Dentist
    {

        [JsonPropertyName("dentist_id")]
        public int dentist_id { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }

        public Dentist()
        {
        }
        
        

    }
}
