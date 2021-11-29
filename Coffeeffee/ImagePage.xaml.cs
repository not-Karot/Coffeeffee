using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using System.IO;
using System.Threading.Tasks;

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

        private void ColorPicker_PickedColorChanged(object sender, Color colorPicked)
        {
            // do whatever you want with the colorPicked value
        }

        public Task<Stream> TransformPhotoAsync(Func<byte, byte, byte, double> pixelOperation)
        {
            return Task.Run(() =>
            {
                var bitmap = new Bitmap(image);
                bitmap.ToPixelArray();
                bitmap.TransformImage(pixelOperation);
                return bitmap.ToImage().AsJPEG().AsStream();
            });
        }
    }
}
