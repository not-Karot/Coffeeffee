using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coffeeffee.Models;

namespace Coffeeffee.Interfaces
{
	public interface IDentist
	{
        Task<IEnumerable<Dentist>> GetDentists();
        Task<Dentist> GetDentist(int id);
        Task AddDentist(Dentist dentist);
        Task SaveDentist(Dentist dentist);
        Task DeleteDentist(Dentist dentist);
    }
}

