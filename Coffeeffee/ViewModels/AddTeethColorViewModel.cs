using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;
using Xamarin.Forms;

namespace Coffeeffee.ViewModels
{
    public class AddTeethColorViewModel : BaseViewModel
    {

        private readonly ITeethColor _TeethColorService;
        private int teethcolor_id;
        private string color;
        private DateTime date;
        private string image;

        private string client;

        public AddTeethColorViewModel(ITeethColor teethColorService)
        {
            _TeethColorService = teethColorService;

            SaveTeethColorCommand = new Command(async () => await SaveTeethcolor());

        }

        private async Task SaveTeethcolor()
        {
            try
            {
                var teethcolor = new TeethColor
                {
                    color = color,
                    date = date,
                    client = client,
                    image = image
                };

                await _TeethColorService.AddTeethColor(teethcolor);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
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

        public ICommand SaveTeethColorCommand { get; }
    }

}