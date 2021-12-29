using System;
using System.IO;
using System.Reflection;
using SkiaSharp;
using Xamarin.Forms;
using Color = System.Drawing.Color;
namespace Coffeeffee.Models
{
    public class Tooth
    {
        public string name { get; }
        public SKBitmap bitmap { get; }
        public Color rgb_color { get; }

        public Tooth(string name, string bitmap, Color rgb_color)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            this.name = name;

            using (Stream stream = assembly.GetManifestResourceStream(bitmap))
            {
                Console.WriteLine("costructor");
                Console.WriteLine(bitmap);

                this.bitmap = SKBitmap.Decode(stream);
            }
        
            this.rgb_color = rgb_color;
        }



    }

}