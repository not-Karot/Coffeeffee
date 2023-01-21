using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;

namespace Coffeeffee.Services
{
	public class ApiClient: IClient

	{
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddClient(Client client)
        {
            var response = await _httpClient.PostAsync("client",
                new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteClient(Client client)
        {
            var response = await _httpClient.DeleteAsync($"client/{client.client_id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<Client> GetClient(int client_id)
        {
            var response = await _httpClient.GetAsync($"client/{client_id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Client>(responseAsString);
        }

        public async Task<IEnumerable<Client>> GetClientsByDentist(int dentist_id)
        {
            Console.WriteLine("££££££££££££££Apiclient£££££££££££");
            var response = await _httpClient.GetAsync($"client/?dentist_id={dentist_id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Client>>(responseAsString);
        }

        public async Task SaveClient(Client client)
        {
            var response = await _httpClient.PutAsync($"client?id={client.client_id}",
                new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}

