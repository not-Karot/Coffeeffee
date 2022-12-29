using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;
using Coffeeffee.Views;
using Xamarin.Forms;

namespace Coffeeffee.ViewModels
{
	public class ClientsViewModel : BaseViewModel
	{
        private ObservableCollection<Client> clients;
        private Client selectedClient;
        private readonly IClient _ClientService;

        public ClientsViewModel(IClient ClientService)
        {
            _ClientService = ClientService;

            Clients = new ObservableCollection<Client>();

            DeleteClientCommand = new Command<Client>(async b => await DeleteClient(b));

            AddNewClientCommand = new Command(async () => await GoToAddClientView());
        }

        private async Task DeleteClient(Client b)
        {
            await _ClientService.DeleteClient(b);

            PopulateClients();
        }

        private async Task GoToAddClientView()
            => await Shell.Current.GoToAsync(nameof(AddClient));

        public async void PopulateClients()
        {
            try
            {
                Clients.Clear();

                var clients = await _ClientService.GetClientsByDentist("1");
                Console.WriteLine("&&&&&&&&&&&&&&&&&&&");
                foreach (var client in clients)
                {
                    Console.WriteLine(client.client_id);
                    Clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnClientSelected(Client client)
        {
            if (client == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ClientDetails)}?{nameof(ClientDetailsViewModel.client_id)}={client.client_id}");
        }

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                //OnPropertyChanged(nameof(Clients));
            }
        }

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;

                    OnClientSelected(SelectedClient);
                }
            }
        }

        public ICommand DeleteClientCommand { get; }

        public ICommand AddNewClientCommand { get; }
    }
    
	
}

