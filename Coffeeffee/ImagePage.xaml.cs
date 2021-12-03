using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;

namespace Coffeeffee
{
    public partial class ImagePage : ContentPage

    {
        public SfImageEditor editor = new SfImageEditor();
      
        public ImagePage(Stream stream)
        {
            InitializeComponent();
           
            image.Source = ImageSource.FromStream(() => stream);

            Console.WriteLine("constructor");

        }



        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        
        private void SfImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {

            args.Cancel = true;
            var stream = args.Stream;
            
        }
    }
}
