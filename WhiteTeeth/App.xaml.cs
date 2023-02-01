using System;
using Plugin.SharedTransitions;
using Xamarin.Forms;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;


namespace WhiteTeeth
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.ConfigureServices();

            Device.SetFlags(new string[] { "Shapes_Experimental" });

            MainPage = new SharedTransitionNavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        

    }
}
