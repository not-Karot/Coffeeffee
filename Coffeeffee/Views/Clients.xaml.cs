using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffeeffee.ViewModels;

namespace Coffeeffee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clients : ContentPage
    {
        private readonly ClientsViewModel _clientsViewModel;

        public Clients()
        {
            InitializeComponent();

            _clientsViewModel = Startup.Resolve<ClientsViewModel>();
            BindingContext = _clientsViewModel;
        }

        protected override void OnAppearing()
        {
            _clientsViewModel?.PopulateClients();
        }
    }
}

