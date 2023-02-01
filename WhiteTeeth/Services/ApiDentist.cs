using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WhiteTeeth.Interfaces;
using WhiteTeeth.Models;

namespace WhiteTeeth.Services
{
	public class ApiDentist : IDentist

	{

        private readonly HttpClient _httpClient;

        public ApiDentist(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddDentist(Dentist dentist)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDentist(Dentist dentist)
        {
            throw new NotImplementedException();
        }

        public async Task<Dentist> GetDentist(int id)
        {
            var response = await _httpClient.GetAsync($"dentist/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dentist>(responseAsString);
        }

        public async Task<IEnumerable<Dentist>> GetDentists()
        {
            var response = await _httpClient.GetAsync("dentist");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Dentist>>(responseAsString);
        }

        public async Task SaveDentist(Dentist dentist)
        {
            throw new NotImplementedException();
        }
        public async Task<Dentist> GetUser(string access_token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                try
                {
                    var userInfoResponse = await client.GetAsync("https://whiteteeth.auth.eu-west-3.amazoncognito.com/oauth2/userInfo");
                    userInfoResponse.EnsureSuccessStatusCode();
                    var userInfoString = await userInfoResponse.Content.ReadAsStringAsync();
                    var userInfo = JsonSerializer.Deserialize<Dictionary<string, string>>(userInfoString);
                    return new Dentist
                    {
                        dentist_id = int.Parse(userInfo["dentist_id"]),
                        username = userInfo["username"],
                        email = userInfo["email"],
                    };
                }
                catch
                {
                    return new Dentist
                    {
                        dentist_id = 1,
                        username = "notkarot",
                        email = "rafael.karot@icloud.com",
                    };
                }

                }

            ;
        }
    }
}

