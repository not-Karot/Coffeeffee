using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WhiteTeeth.Interfaces;
using WhiteTeeth.Models;
using WhiteTeeth.Views;
using Xamarin.Forms;

namespace WhiteTeeth.ViewModels
{
	public class DentistsViewModel : BaseViewModel
    {
        public ObservableCollection<Dentist> dentists;
        private Dentist selectedDentist;
        private readonly IDentist _dentistService;

        public DentistsViewModel(IDentist DentistService)
		{
            _dentistService = DentistService;

            Dentists = new ObservableCollection<Dentist>();

            DeleteDentistCommand = new Command<Dentist>(async b => await DeleteDentist(b));

            //AddNewDentistCommand = new Command(async () => await GoToAddClientView());


        }
        public void SetSelectedClient(string id)
        {
            var dent = Dentists.FirstOrDefault(d => d.dentist_id == int.Parse(id));
            SelectedDentist = dent;
        }

        private async Task DeleteDentist(Dentist d)
        {
            await _dentistService.DeleteDentist(d);

            await PopulateDentists();
        }
        //private async Task GoToAddClientView()
        //=> await Shell.Current.GoToAsync(nameof(AddClient));

        public async Task PopulateDentists()
        {
            try
            {
                Dentists.Clear();
                var dentists = await _dentistService.GetDentists();

                foreach (var dentist in dentists)
                {
                    Dentists.Add(dentist);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async void OnDentistSelected(Dentist dentist)
        {
            if (dentist == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(LoginPage)}?{nameof(DentistDetailsViewModel.Dentist_id)}={dentist.dentist_id}");
        }

        public ObservableCollection<Dentist> Dentists
        {
            get => dentists;
            set
            {
                dentists = value;
                OnPropertyChanged(nameof(Dentists));
            }
        }

        public Dentist SelectedDentist
        {
            get => selectedDentist;
            set
            {
                if (selectedDentist != value)
                {
                    selectedDentist = value;

                    OnDentistSelected(selectedDentist);
                }
            }
        }

        public ICommand DeleteDentistCommand { get; }

        //public ICommand AddNewDentistCommand { get; }
    }
}

