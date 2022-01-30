using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Coffeeffee.Models;
using Xamarin.Forms;

namespace Coffeeffee
{
    public partial class LoginPage : ContentPage
    {
        public User user;
        public LoginPage()
        {
            InitializeComponent();
            
        }

        async void ExecuteLoginCommand()
        {
            
            try
            {
                var url = new Uri("https://whiteteeth.auth.eu-west-3.amazoncognito.com/oauth2/authorize?client_id=c37hj343ukrcs60p1pp62867f&response_type=code&scope=email+openid+phone&redirect_uri=whiteteeth%3A%2F%2F");
                var callbackUrl = new Uri("whiteteeth://");

                var authResult = await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
                {
                    Url = url,
                    CallbackUrl = callbackUrl,
                    PrefersEphemeralWebBrowserSession = true
                });
                var accessToken = authResult?.AccessToken;
               user = new User(accessToken);

            }catch(TaskCanceledException e)
            {
                
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            ExecuteLoginCommand();
        }
    }
}
