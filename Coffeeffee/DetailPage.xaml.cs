using System;
using System.Collections.Generic;
using Coffeeffee.Models;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Essentials;
using Coffeeffee.Views;

namespace Coffeeffee
{
    public partial class DetailPage : ContentPage
    {
        SKPaint greenPaint = new SKPaint() { Color = SKColor.Parse("#2E8A8F") };
        SKPath wavePath = SKPath.ParseSvgPathData("M615.59,178.35c-86.88,0-129.26-89.18-129.26-89.18S435.14,14,375,14,263.63,89.17,263.63,89.17s-42.2,89.18-129.26,89.18S0,0,0,0V200H750V0S702.61,178.35,615.59,178.35Z");

        public DetailPage(Treatment treatment)
        {
            InitializeComponent();

            BindingContext = treatment;
        }

        void SKCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear();

            var pathInfo = wavePath.Bounds;
            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Translate(width / 2f, height / 2f);

            var xRatio = width / pathInfo.Width;
            var yRatio = height / pathInfo.Height;
            var ratio = Math.Min(xRatio, yRatio);

            canvas.Scale(ratio);
            canvas.Translate(-wavePath.Bounds.MidX, 0);

            canvas.DrawPath(wavePath, greenPaint);

            canvas.Save();
        }

        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void PeopleClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Clients());
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
    }
}
