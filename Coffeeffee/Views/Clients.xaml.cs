using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffeeffee.ViewModels;
using SkiaSharp;
using Xamarin.Essentials;

namespace Coffeeffee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clients : ContentPage
    {
        SKPaint whitePaint = new SKPaint() { Color = SKColor.Parse("#FFFFFF") };
        SKPath wavePath = SKPath.ParseSvgPathData("M615.59,178.35c-86.88,0-129.26-89.18-129.26-89.18S435.14,14,375,14,263.63,89.17,263.63,89.17s-42.2,89.18-129.26,89.18S0,0,0,0V200H750V0S702.61,178.35,615.59,178.35Z");

        private readonly ClientsViewModel _clientsViewModel;

        public Clients()
        {
            InitializeComponent();

            _clientsViewModel = Startup.Resolve<ClientsViewModel>();
            BindingContext = _clientsViewModel;
            Console.WriteLine(_clientsViewModel.Clients);
        }

        protected override async void OnAppearing()
        {
            Console.WriteLine("onappearing");
            _clientsViewModel.IsLoading = true;
            await _clientsViewModel.PopulateClients();
            _clientsViewModel.IsLoading = false;
            Console.WriteLine(_clientsViewModel.IsLoading);
            Console.WriteLine(_clientsViewModel.Clients.Count);
        }
        
        async void Settings_Button(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());
        }
        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Take_Photo_Button(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                await Navigation.PushAsync(new ImagePage(stream));
            }

        }
        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}

