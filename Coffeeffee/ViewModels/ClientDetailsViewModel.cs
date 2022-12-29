using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;

namespace Coffeeffee.ViewModels
{
    [QueryProperty(nameof(ClientId), nameof(ClientId))]
    public class ClientDetailsViewModel : BaseViewModel
    {
        public string client_id;
        private string name;
        private string surname;
        private Dentist dentist;
        private readonly IClient _ClientService;

        public ClientDetailsViewModel(IClient ClientService)
        {
            _ClientService = ClientService;

            SaveClientCommand = new Command(async () => await SaveClient());
        }

        private async Task SaveClient()
        {
            try
            {
                var client = new Client
                {
                    client_id = client_id,
                    name = name,
                    surname = surname,
                    dentist = dentist
                };

                await _ClientService.SaveClient(client);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadClient(string client_id)
        {
            try
            {
                var Client = await _ClientService.GetClient(client_id);
                if (ClientId != null)
                {
                    name = Client.name;
                    surname = Client.surname;
                    dentist = Client.dentist;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ClientId
        {
            get => ClientId;
            set
            {
                ClientId = value;
                LoadClient(ClientId);
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
        public Dentist Dentistc
        {
            get => dentist;
            set
            {
                dentist = value;
                OnPropertyChanged(nameof(Dentistc.dentist_id));
            }
        }

        public ICommand SaveClientCommand { get; }
    }
}


