using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using System.IO;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;
using System.Drawing;
using Color = System.Drawing.Color;

namespace Coffeeffee
{
    public partial class ImagePage : ContentPage

    {
        public SfImageEditor editor = new SfImageEditor();
        ColorIdentifier identifier = new ColorIdentifier();

        public ImagePage(Stream stream)
        {
            InitializeComponent();
            
           
            image.Source = ImageSource.FromStream(() => stream);

        }

        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        
        private void SfImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {

            args.Cancel = true;
            var stream = args.Stream;
            
            
            SKBitmap bitmap =  SKBitmap.Decode(stream);

            //SKColor[] pixels = bitmap.Pixels;

            //bitmap.Pixels = pixels;



            Console.WriteLine(this.identifier.GetRightTooth(bitmap).name);
            //Console.WriteLine(GetDominantColor(pixels));
            //getMaxOccurrence(pixels);


        }


        
    }
}
