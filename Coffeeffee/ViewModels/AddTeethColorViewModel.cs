using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffeeffee.Interfaces;
using Coffeeffee.Models;
using Xamarin.Forms;

namespace Coffeeffee.ViewModels
{
    public class AddTeethColorViewModel : BaseViewModel
    {

        public readonly ITeethColor _TeethColorService;
        private int teethcolor_id;
        private string color;
        private DateTime date;
        private string image;
        private byte[] byteImage;
        private string client;

        public AddTeethColorViewModel(ITeethColor teethColorService)
        {
            _TeethColorService = teethColorService;
            Console.WriteLine("save");
            SaveTeethColorCommand = new Command(async () => await SaveTeethcolor());

        }

        private async Task SaveTeethcolor()
        {
            Console.WriteLine("add");
            try
            {
                var content = new MultipartFormDataContent();


                Console.WriteLine("ByteImage");
                content.Add(new ByteArrayContent(ByteImage), "image", "image.jpg");
                Console.WriteLine("Color");
                content.Add(new StringContent(Color), "color");

                Console.WriteLine("Client");

                content.Add(new StringContent($"http://whitesite.fly.dev/client/{Client}/"), "client");

                Console.WriteLine("DateTime");
                var currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                content.Add(new StringContent(currentDate), "date");

                await _TeethColorService.AddTeethColor(content);

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

        public byte[] ByteImage
        {
            get => byteImage;
            set
            {
                byteImage = value;
                OnPropertyChanged(nameof(ByteImage));
            }
        }

        public ICommand SaveTeethColorCommand { get; }
    }

}