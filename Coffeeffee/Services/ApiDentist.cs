using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;

namespace Coffeeffee.Services
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
    }
}

