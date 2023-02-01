using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhiteTeeth.ViewModels;
using SkiaSharp;
using Xamarin.Essentials;

using WhiteTeeth.Models;
using Plugin.SharedTransitions;

namespace WhiteTeeth.Views
{	
	public partial class Dentists : ContentPage
	{

        private readonly DentistsViewModel _dentistsViewModel;

        public Dentists ()
		{
			InitializeComponent ();
            _dentistsViewModel = Startup.Resolve<DentistsViewModel>();
            BindingContext = _dentistsViewModel;
        }
        protected override async void OnAppearing()
        {
            await _dentistsViewModel.PopulateDentists();
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

        async void Login_Button(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());
        }

        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}

