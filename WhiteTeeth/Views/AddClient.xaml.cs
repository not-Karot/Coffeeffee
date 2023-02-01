using System;
using System.Collections.Generic;
using WhiteTeeth.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WhiteTeeth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClient : ContentPage
    {
        private readonly AddClientViewModel _addClientViewModel;
        public AddClient()
        {
            InitializeComponent();
            _addClientViewModel = Startup.Resolve<AddClientViewModel>();

            _addClientViewModel.NavigateToHome += OnNavigateToHome;
           
            BindingContext = _addClientViewModel;
        }
        private void OnNavigateToHome(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        async void PeopleClicked(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Clients());
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
                _addClientViewModel._Image = result.FullPath;
                _addClientViewModel.Dentist = "1";
            }


        }
        async void Load_Photo_Button(System.Object sender, System.EventArgs e)
        {

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                _addClientViewModel._Image = result.FullPath;
                _addClientViewModel.Dentist = "1";

            }
        }
        

    }
}

