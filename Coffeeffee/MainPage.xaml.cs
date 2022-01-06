using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using Coffeeffee.Models;
using Plugin.SharedTransitions;
using Xamarin.Essentials;
using System.Reflection;
using System.IO;

namespace Coffeeffee
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKPaint whitePaint = new SKPaint() { Color = SKColor.Parse("#FFFFFF") };
        SKPath wavePath = SKPath.ParseSvgPathData("M615.59,178.35c-86.88,0-129.26-89.18-129.26-89.18S435.14,14,375,14,263.63,89.17,263.63,89.17s-42.2,89.18-129.26,89.18S0,0,0,0V200H750V0S702.61,178.35,615.59,178.35Z");
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new List<Treatment>
            {
                new Treatment { Title="Temporary", Image="tooth_caps",
                    Subtitle="This is the temporary capsule for your new tooth",
                },
                new Treatment { Title="Ultimate", Image="final_caps",  Subtitle="This is your new wonderful tooth"}, 
                new Treatment { Title="Whitening", Image="whitening", Subtitle="This treatment will give you a new wonderful smile" },
            };
        }

        //void SKCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        //{
        //    var canvas = e.Surface.Canvas;

        //    canvas.Clear();

        //    var pathInfo = wavePath.Bounds;
        //    var width = e.Info.Width;
        //    var height = e.Info.Height;

        //    canvas.Translate(width / 2f, height / 2f);

        //    var xRatio = width / pathInfo.Width;
        //    var yRatio = height / pathInfo.Height;
        //    var ratio = Math.Min(xRatio, yRatio);

        //    canvas.Scale(ratio);
        //    canvas.Translate(-wavePath.Bounds.MidX, 0);

        //    canvas.DrawPath(wavePath, whitePaint);

        //    canvas.Save();
        //}

        async void Image_Tapped(System.Object sender, System.EventArgs e)
        {    
            var model = (sender as Image).BindingContext as Treatment;

            //this is required in order to pass the views to animate
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(this, model.Title);

            await Navigation.PushAsync(new DetailPage(model));
        }
        async void Settings_Button(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());
        }
        async void Take_Photo_Button(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                await Navigation.PushAsync(new ImagePage(stream));
            }
            

        }
        async void Load_Photo_Button(System.Object sender, System.EventArgs e)
        {
            
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                await Navigation.PushAsync(new ImagePage(stream));

            }

           

        }

    }
}
