using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;
using System.Drawing;
using Coffeeffee.Views;
using Coffeeffee.ViewModels;
using Color = System.Drawing.Color;
using System.Linq;
using System.Net.Http;

namespace Coffeeffee
{
    public partial class ImagePage : ContentPage

    {
        public SfImageEditor editor = new SfImageEditor();
        ColorIdentifier identifier = new ColorIdentifier();
        private readonly ClientsViewModel _clientsViewModel;
        private readonly AddTeethColorViewModel _teethAddColorViewModel;
        private Stream image_stream;

        private Tooth currentTooth = new Tooth("Result tooth will be shown here", "Coffeeffee.Resources.Scala_vita.png", Color.FromArgb(0, 0, 0), "Scala_vita.png");

        public ImagePage(Stream stream)
        {
            InitializeComponent();

            _clientsViewModel = Startup.Resolve<ClientsViewModel>();
            BindingContext = _clientsViewModel;

            _teethAddColorViewModel = Startup.Resolve<AddTeethColorViewModel>();
            BindingContext = _teethAddColorViewModel;

            image.Source = ImageSource.FromStream(() => stream);
            BindingContext = currentTooth;

        }
        protected override async void OnAppearing()
        {
            await _clientsViewModel.PopulateClients();
        }

        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async void PeopleClicked(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Clients());
        }

        async void SaveClicked(System.Object sender, System.EventArgs e)
        {
            var clientDict = new Dictionary<string, int>();
            foreach (var client in _clientsViewModel.Clients)
            {
                clientDict.Add(client.surname, client.client_id);
            }
            
            var action = await DisplayActionSheet("Seleziona un cliente", "Annulla", null, clientDict.Keys.ToArray());
            if (action != "Annulla")
            {
                var imageByteArray = new byte[image_stream.Length];
                image_stream.Read(imageByteArray, 0, (int)image_stream.Length);
                var teethcolor = new TeethColor
                {
                    color = currentTooth.name,
                    date = DateTime.Now,
                    client = clientDict[action].ToString(),
                    image = imageByteArray
            };
                _teethAddColorViewModel._TeethColorService.AddTeethColor(teethcolor);


            }
            //await Navigation.PushAsync(new Clients());
        }

        private void SfImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {

            args.Cancel = true;
            var stream = args.Stream;
            image_stream = stream;
            
            SKBitmap bitmap =  SKBitmap.Decode(stream);

           

            BindingContext = this.identifier.GetRightTooth(bitmap);
            currentTooth = this.identifier.GetRightTooth(bitmap);
            Console.WriteLine(this.identifier.GetRightTooth(bitmap).name);


        }


        
    }
}
