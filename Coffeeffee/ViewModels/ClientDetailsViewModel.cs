using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;

namespace Coffeeffee.ViewModels
{
    [QueryProperty(nameof(Client_id), nameof(Client_id))]
    public class ClientDetailsViewModel : BaseViewModel
    {
        private string client_id;
        private string name;
        private string surname;
        private string dentist;
        private string image;
        private readonly IClient _clientService;

        public ClientDetailsViewModel(IClient clientService)
        {
            _clientService = clientService;

            SaveClientCommand = new Command(async () => await SaveClient());
        }

        private async Task SaveClient()
        {
            try
            {
                var client = new Client
                {
                    client_id = int.Parse(Client_id),
                    name = Name,
                    surname = Surname,
                    dentist = Dentist,
                    image = _Image
                };

                await _clientService.SaveClient(client);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadClient(string clientId)
        {
            try
            {
                var client = await _clientService.GetClient(int.Parse(clientId));
                if (clientId != null)
                {
                    Name = client.name;
                    Surname = client.surname;
                    Dentist = client.dentist;
                    _Image = client.image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Client_id
        {
            get => client_id;
            set
            {
                client_id = value;
                LoadClient(Client_id);
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Dentist
        {
            get => dentist;
            set
            {
                dentist = value;
                OnPropertyChanged(nameof(Dentist));
            }
        }
        public string _Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(_Image));
            }
        }

        public ICommand SaveClientCommand { get; }
    }
}