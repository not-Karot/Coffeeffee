using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using SkiaSharp;
using Xamarin.Forms;
using Color = System.Drawing.Color;
namespace WhiteTeeth.Models
{
    public class Tooth
    {

        [JsonPropertyName("name")]
        public string name { get; }

        [JsonPropertyName("bitmap")]
        public SKBitmap bitmap { get; }

        [JsonPropertyName("rgb_color")]
        public Color rgb_color { get; }

        [JsonPropertyName("image")]
        public string image { get; }


        public Tooth(string name, string bitmap, Color rgb_color, string image)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            this.name = name;

            using (Stream stream = assembly.GetManifestResourceStream(bitmap))
            {
                
                this.bitmap = SKBitmap.Decode(stream);
            }
        
            this.rgb_color = rgb_color;
            this.image = image;
        }


        public Tooth(string name, string bitmap, Color rgb_color)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            this.name = name;

            using (Stream stream = assembly.GetManifestResourceStream(bitmap))
            {


                this.bitmap = SKBitmap.Decode(stream);
            }

            this.rgb_color = rgb_color;
        }

        }

}