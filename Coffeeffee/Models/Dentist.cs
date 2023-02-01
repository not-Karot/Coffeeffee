using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public Dentist(int dentist_id)
        {
            
            this.dentist_id = dentist_id;
        }
        public async Task<Dentist> GetUser(string access_token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                var userInfoResponse = await client.GetAsync("https://whiteteeth.auth.eu-west-3.amazoncognito.com/oauth2/userInfo");
                userInfoResponse.EnsureSuccessStatusCode();
                var userInfoString = await userInfoResponse.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(userInfoString);
                return new Dentist({
                    dentist_id = userInfo["email"],
                    username = userInfo["username"],
                    email = userInfo["email"],
                })
                // do something with the user info
            }

            ;
        }

    }
}
