using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using System.IO;

namespace Coffeeffee
{
    public partial class ImagePage : ContentPage
        
    {
       
        public ImagePage(Stream stream)
        {
            InitializeComponent();
            image.Source = ImageSource.FromStream(() => stream);

        }



        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
