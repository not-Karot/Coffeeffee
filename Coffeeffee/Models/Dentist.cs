using System;
using System.Text.Json.Serialization;

namespace Coffeeffee.Models
{
    public class Dentist
    {

        [JsonPropertyName("dentist_id")]
        public string dentist_id { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("email")]
        private string email { get; set; }

        [JsonPropertyName("password")]
        private string password { get; set; }

        public Dentist()
        {
        }
        public Dentist(string dentist_id)
        {
            
            this.dentist_id = dentist_id;
        }
    }
}
