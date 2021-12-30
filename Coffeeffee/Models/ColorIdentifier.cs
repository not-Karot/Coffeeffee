using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SkiaSharp;
using Xamarin.Forms;
using Color = System.Drawing.Color;
namespace Coffeeffee.Models
{
    public class ColorIdentifier
    {
        private Tooth[] scale;
        private Teeth teeth = new Teeth();

        public ColorIdentifier()
        {
            this.scale = this.teeth.teeth;
        }

        public Tooth GetRightTooth(SKBitmap image)
        {

            image = image.Resize(scale[0].bitmap.Info, SKFilterQuality.Medium);

            SKColor[] to_compare = image.Pixels;


            string name = "";
            long best= long.MaxValue;

            foreach (Tooth step in scale)
            {
                int step_total = 0;
                SKColor[] comparable = step.bitmap.Pixels;

                for(int i=0; i<to_compare.Length; i++)
                {
                    step_total += Math.Abs(to_compare[i].Red - comparable[i].Red);
                    step_total += Math.Abs(to_compare[i].Blue -comparable[i].Blue);
                    step_total += Math.Abs(to_compare[i].Green - comparable[i].Green);
                }
                

                if (step_total < best)
                {
                    best = step_total;
                    name = step.name;
                }

            }
            return this.teeth.getToothByName(name);

        }
        public static Color GetDominantColor(SKColor[] bmp)
        {

            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            foreach (SKColor color in bmp)
            {
                r += color.Red;
                g += color.Green;
                b += color.Blue;

                total++;
            }




            //Calculate average
            r /= total;
            g /= total;
            b /= total;


            return Color.FromArgb(r, g, b);
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
