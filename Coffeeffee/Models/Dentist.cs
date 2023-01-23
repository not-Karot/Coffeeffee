using System;
using System.Text.Json.Serialization;

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
        public Dentist(int dentist_id)
        {
            
            this.dentist_id = dentist_id;
        }
        public Dentist(string access_token)
        {

            ;
        }
    }
}
