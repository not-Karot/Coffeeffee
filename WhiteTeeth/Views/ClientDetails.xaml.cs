using System;
using System.Collections.Generic;
using WhiteTeeth.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhiteTeeth.Models;

namespace WhiteTeeth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetails : ContentPage
    {
        private readonly ClientDetailsViewModel _clientDetailsViewModel;
        private readonly TeethColorViewModel _teethColorViewModel;
        public string current_client_id;
        public ClientDetails(Client client)
        {
            
            InitializeComponent();
            current_client_id = client.client_id.ToString();
            _clientDetailsViewModel = Startup.Resolve<ClientDetailsViewModel>();
            BindingContext = _clientDetailsViewModel;

            _teethColorViewModel = Startup.Resolve<TeethColorViewModel>();
            BindingContext = _teethColorViewModel;

        }

        protected override async void OnAppearing()
        {
            

            await _teethColorViewModel.PopulateTeethColors(current_client_id);
           

        }

        async void Login_Button(System.Object sender, System.EventArgs e)
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

