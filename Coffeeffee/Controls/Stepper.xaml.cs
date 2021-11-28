using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Coffeeffee.Controls
{
    public partial class Stepper : Frame
    {
        public Stepper()
        {
            InitializeComponent();
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
