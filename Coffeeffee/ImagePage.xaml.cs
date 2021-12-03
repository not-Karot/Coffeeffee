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

            SKColor[] pixels = bitmap.Pixels;

            bitmap.Pixels = pixels;
            getMaxOccurrence(pixels);


        }

        public static void getMaxOccurrence(SKColor[] numbers)
        {
            var counts = new Dictionary<SKColor, int>();
            foreach (SKColor number in numbers)
            {
                int count;
                counts.TryGetValue(number, out count);
                count++;
                //Automatically replaces the entry if it exists;
                //no need to use 'Contains'
                counts[number] = count;
            }
            SKColor mostCommonNumber = 0;
            int occurrences = 0;
            foreach (var pair in counts)
            {
                if (pair.Value > occurrences)
                {
                    occurrences = pair.Value;
                    mostCommonNumber = pair.Key;
                }
            }
            Console.WriteLine("The most common number is {0} and it appears {1} times",
                mostCommonNumber, occurrences);
        }
    }
}
