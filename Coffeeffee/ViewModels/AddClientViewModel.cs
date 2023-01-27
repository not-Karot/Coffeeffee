using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;
using Xamarin.Forms;
using Plugin.SharedTransitions;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
namespace Coffeeffee.ViewModels
{
    public class AddClientViewModel : BaseViewModel
    {
        private readonly IClient _ClientService;
        public int client_id;
        private string name;
        private string surname;
        private string dentist;
        private string image;

        public AddClientViewModel(IClient ClientService)
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

                    name = name,
                    surname = surname,
                    dentist =  dentist,
                    image= image
                };

                await _ClientService.AddClient(client);

                NavigateToHome?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NavigateToHome?.Invoke(this, EventArgs.Empty);
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

        public event EventHandler<EventArgs> NavigateToHome;

        public ICommand SaveClientCommand { get; }
    }
}