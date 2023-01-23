using System;
using Coffeeffee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace Coffeeffee.Interfaces
{
	public interface ITeethColor
	{
        Task<IEnumerable<TeethColor>> GetTeethColorsByClient(string client_id);
        Task<TeethColor> GetTeethColor(string teethcolor_id);
        Task AddTeethColor(TeethColor teethcolor);
        Task SaveTeethColor(TeethColor teethcolor);
        Task DeleteTeethColor(TeethColor teethcolor);
        Task AddTeethColor(MultipartFormDataContent content);
    }
}

