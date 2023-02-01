using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using SkiaSharp;
using Xamarin.Forms;
using WhiteTeeth.Models;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;
using System.Drawing;
using WhiteTeeth.Views;
using WhiteTeeth.ViewModels;
using Color = System.Drawing.Color;
using System.Linq;
using System.Net.Http;
using Amazon.Runtime.Internal;
using Amazon.SecurityToken.Model;

namespace WhiteTeeth
{
    public partial class ImagePage : ContentPage

    {
        public SfImageEditor editor = new SfImageEditor();
        ColorIdentifier identifier = new ColorIdentifier();
        private readonly ClientsViewModel _clientsViewModel;
        private readonly AddTeethColorViewModel _teethAddColorViewModel;
        private byte[] fileBytes;

        private Tooth currentTooth = new Tooth("Result tooth will be shown here", "WhiteTeeth.Resources.Scala_vita.png", Color.FromArgb(0, 0, 0), "Scala_vita.png");

        public ImagePage(Stream stream)
        {
            InitializeComponent();

            _clientsViewModel = Startup.Resolve<ClientsViewModel>();
            BindingContext = _clientsViewModel;

            _teethAddColorViewModel = Startup.Resolve<AddTeethColorViewModel>();
            _teethAddColorViewModel.NavigateToHome += OnNavigateToHome;
            BindingContext = _teethAddColorViewModel;

            image.Source = ImageSource.FromStream(() => stream);
            BindingContext = currentTooth;

        }
        private void OnNavigateToHome(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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
                
                _teethAddColorViewModel.ByteImage = fileBytes;
                _teethAddColorViewModel.Color = currentTooth.name;
                _teethAddColorViewModel.Client = clientDict[action].ToString();

                _teethAddColorViewModel.SaveTeethColorCommand.Execute(null);

            }
            //await Navigation.PushAsync(new Clients());
        }

        private void SfImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {

            args.Cancel = true;


            using (var stream = args.Stream) // use "using" to dispose the stream after use
            {
                
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                var bitmap = SKBitmap.Decode(fileBytes);
                BindingContext = this.identifier.GetRightTooth(bitmap);
                currentTooth = this.identifier.GetRightTooth(bitmap);
            }
        }




    }
}
