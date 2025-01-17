﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WhiteTeeth.Interfaces;
using WhiteTeeth.Models;
using WhiteTeeth.Views;
using Xamarin.Forms;

namespace WhiteTeeth.ViewModels
{
	public class ClientsViewModel : BaseViewModel
	{
        public ObservableCollection<Client> clients;
        private Client selectedClient;
        private readonly IClient _clientService;
        
        public ClientsViewModel(IClient ClientService)
        {
            _clientService = ClientService;

            Clients = new ObservableCollection<Client>();

            DeleteClientCommand = new Command<Client>(async b => await DeleteClient(b));

            AddNewClientCommand = new Command(async () => await GoToAddClientView());
        }

        private async Task DeleteClient(Client b)
        {
            await _clientService.DeleteClient(b);

            await PopulateClients();
        }

        private async Task GoToAddClientView()
            => await Shell.Current.GoToAsync(nameof(AddClient));

        public async Task PopulateClients()
        {
            try
            {
                Clients.Clear();
                var clients = await _clientService.GetClientsByDentist(1);
                
                foreach (var client in clients)
                {
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

            await Shell.Current.GoToAsync($"{nameof(ClientDetails)}?{nameof(ClientDetailsViewModel.Client_id)}={client.client_id}");
        }

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
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

