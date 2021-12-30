using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;
using Coffeeffee.Models;
using Coffeeffee.Models.Cropping;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor.XForms;
using System.Drawing.Design;
using Color = System.Drawing.Color;
using SkiaSharp.Views.Forms;


namespace Coffeeffee
{
    public partial class ImagePage : ContentPage

    {
        public SfImageEditor editor = new SfImageEditor();
        ColorIdentifier identifier = new ColorIdentifier();

        PhotoCropperCanvasView photoCropper;
        SKBitmap croppedBitmap;

        public ImagePage(Stream stream)
        {
            InitializeComponent();

            SKBitmap bitmap = SKBitmap.Decode(stream);

            photoCropper = new PhotoCropperCanvasView(bitmap);
            canvasViewHost.Children.Add(photoCropper);
            //image.Source = ImageSource.FromStream(() => stream);

        }

        async void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        void OnDoneButtonClicked(object sender, EventArgs args)
        {
            croppedBitmap = photoCropper.CroppedBitmap;

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmap(croppedBitmap, info.Rect, BitmapStretch.Uniform);
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
