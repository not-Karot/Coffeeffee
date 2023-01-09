using Coffeeffee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coffeeffee.Interfaces
{
	public interface IClient
	{
        Task<IEnumerable<Client>> GetClientsByDentist(int dentist_id);
        Task<Client> GetClient(int client_id);
        Task AddClient(Client client);
        Task SaveClient(Client client);
        Task DeleteClient(Client client);
    }
}

