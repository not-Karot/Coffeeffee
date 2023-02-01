using System;

using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WhiteTeeth.Interfaces;
using WhiteTeeth.Models;
namespace WhiteTeeth.Services
{
	public class ApiTeethColor : ITeethColor
    {
        private readonly HttpClient _httpTeethColor;

        public ApiTeethColor(HttpClient httpTeethColor)
        {
            _httpTeethColor = httpTeethColor;
        }

        public async Task AddTeethColor(TeethColor teethColor)
        {
            var response = await _httpTeethColor.PostAsync("teethColor",
                new StringContent(JsonSerializer.Serialize(teethColor), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task AddTeethColor(MultipartFormDataContent content)
        {
            
            var response = await _httpTeethColor.PostAsync("teethColor", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTeethColor(TeethColor teethColor)
        {
            var response = await _httpTeethColor.DeleteAsync($"teethColor/{teethColor.teethcolor_id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<TeethColor> GetTeethColor(string teethColor_id)
        {
            var response = await _httpTeethColor.GetAsync($"teethColor/{teethColor_id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TeethColor>(responseAsString);
        }

        public async Task<IEnumerable<TeethColor>> GetTeethColorsByClient(string client_id)
        {
            
            var response = await _httpTeethColor.GetAsync($"teethColor/?client_id={client_id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TeethColor>>(responseAsString);
        }

        public async Task SaveTeethColor(TeethColor teethColor)
        {
            var response = await _httpTeethColor.PutAsync($"teethColor?id={teethColor.teethcolor_id}",
                new StringContent(JsonSerializer.Serialize(teethColor), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}

