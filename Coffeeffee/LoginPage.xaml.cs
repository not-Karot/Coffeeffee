using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Coffeeffee.Models;
using Xamarin.Forms;
using Coffeeffee.Views;
using Amazon.CognitoIdentity;
using Coffeeffee.ViewModels;


namespace Coffeeffee
{
    public partial class LoginPage : ContentPage
    {
        public Dentist user;
        private DentistDetailsViewModel _dentistDetailsViewModel;
        public LoginPage()
        {
            InitializeComponent();
            _dentistDetailsViewModel = Startup.Resolve<DentistDetailsViewModel>();
            BindingContext = _dentistDetailsViewModel;
            
        }

        async void ExecuteLoginCommand()
        {
            
            try
            {
                var url = new Uri("https://whiteteeth.auth.eu-west-3.amazoncognito.com/login?client_id=c37hj343ukrcs60p1pp62867f&response_type=code&scope=email+openid+phone&redirect_uri=whiteteeth://");
                
                var callbackUrl = new Uri("Coffeeffee://");

                var authResult = await WebAuthenticator.AuthenticateAsync(
                    url,
                    callbackUrl
                    );
                var accessToken = authResult?.AccessToken;
                user = new Dentist(accessToken);
                _dentistDetailsViewModel.LoadDentist("1");
                
                Console.WriteLine(accessToken);
                foreach (KeyValuePair<string, string> kvp in authResult.Properties)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                

            }
            catch(TaskCanceledException e)
            {
                
            }
        }

        async void PeopleClicked(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Clients());
        }


        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void Login_Button(System.Object sender, System.EventArgs e)
        {
            ExecuteLoginCommand();
        }

    }
}
