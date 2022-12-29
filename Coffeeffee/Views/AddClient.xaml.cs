using System;
using System.Collections.Generic;
using Coffeeffee.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffeeffee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClient : ContentPage
    {
        public AddClient()
        {
            InitializeComponent();

            BindingContext = Startup.Resolve<AddClientViewModel>();
        }
    }
}

