using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Coffeeffee.Models;
using Xamarin.Forms;
using Coffeeffee.Views;
using Amazon.CognitoIdentity;

namespace Coffeeffee
{
    public partial class LoginPage : ContentPage
    {
        public Dentist user;
        public LoginPage()
        {
            InitializeComponent();
            
        }

        async void ExecuteLoginCommand()
        {
            
            try
            {
                var url = new Uri("https://whiteteeth.auth.eu-west-3.amazoncognito.com/login?client_id=c37hj343ukrcs60p1pp62867f&response_type=code&scope=email+openid+phone&redirect_uri=whiteteeth://");
                
                var callbackUrl = new Uri("whiteteeth://");

                var authResult = await WebAuthenticator.AuthenticateAsync(
                    url,
                    callbackUrl
                    );
                var accessToken = authResult?.AccessToken;
                user = new Dentist(accessToken);
                Console.WriteLine("$$$$$$$$$$$$$");

                Console.WriteLine(accessToken);
                Console.WriteLine("$$$$$$$$$$$$$");
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
    }
}
