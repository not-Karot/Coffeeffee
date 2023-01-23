using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;

namespace Coffeeffee.ViewModels
{
    [QueryProperty(nameof(Dentist_id), nameof(Dentist_id))]
    public class DentistDetailsViewModel : BaseViewModel
	{
        private string dentist_id;
        private string username;
        private string email;
        private string password;
        private readonly IDentist _dentistService;

        public DentistDetailsViewModel(IDentist dentistService)
		{
            _dentistService = dentistService;
            SaveDentistCommand = new Command(async () => await SaveDentist());

        }

        private async Task SaveDentist()
        {
            try
            {
                var dentist = new Dentist
                {
                    dentist_id = int.Parse(Dentist_id),
                    username = Username,
                    email = Email,
                    password = Password
                };

                await _dentistService.SaveDentist(dentist);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void LoadDentist(string dentistId)
        {
            try
            {
                var dentist = await _dentistService.GetDentist(int.Parse(dentistId));
                if (dentistId != null)
                {
                    Username = dentist.username;
                    Email = dentist.email;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Dentist_id
        {
            get => dentist_id;
            set
            {
                dentist_id = value;
                LoadDentist(Dentist_id);
            }
        }


        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SaveDentistCommand { get; }
    }
}

