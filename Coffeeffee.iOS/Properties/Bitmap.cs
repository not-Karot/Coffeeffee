using System;
using System.Runtime.InteropServices;
using Coffeeffee.Models;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IBitmap<UIImage>))]
namespace Coffeeffee.iOS.Properties
{
    public class Bitmap : IBitmap<UIImage>
    {
        const byte bitsPerComponent = 8;
        const byte bytesPerPixel = 4;
        UIImage image;
        readonly int width;
        readonly int height;
        IntPtr rawData;
        byte[] pixelData;
        UIImageOrientation orientation;

        public Bitmap(UIImage uiImage)
        {
            image = uiImage;
            orientation = image.Orientation;
            width = (int)image.CGImage.Width;
            height = (int)image.CGImage.Height;
        }

        public void ToPixelArray()
        {
            using (var colourSpace = CGColorSpace.CreateDeviceRGB())
            {
                rawData = Marshal.AllocHGlobal(width * height * 4);
                using (var context = new CGBitmapContext(rawData, width, height, bitsPerComponent, bytesPerPixel * width, colourSpace, CGImageAlphaInfo.PremultipliedLast))
                {
                    context.DrawImage(new CGRect(0, 0, width, height), image.CGImage);
                    pixelData = new byte[width * height * bytesPerPixel];
                    Marshal.Copy(rawData, pixelData, 0, pixelData.Length);
                    Marshal.FreeHGlobal(rawData);
                }
            }
        }

        public void TransformImage(Func<byte, byte, byte, double> pixelOperation)
        {
            byte r, g, b;

            // Pixel data order is RGBA
            try
            {
                for (int i = 0; i < pixelData.Length; i += bytesPerPixel)
                {
                    r = pixelData[i];
                    g = pixelData[i + 1];
                    b = pixelData[i + 2];

                    // Leave alpha value intact
                    pixelData[i] = pixelData[i + 1] = pixelData[i + 2] = (byte)pixelOperation(r, g, b);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public UIImage ToImage()
        {
            using (var dataProvider = new CGDataProvider(pixelData, 0, pixelData.Length))
            {
                using (var colourSpace = CGColorSpace.CreateDeviceRGB())
                {
                    using (var cgImage = new CGImage(width, height, bitsPerComponent, bitsPerComponent * bytesPerPixel, bytesPerPixel * width, colourSpace, CGBitmapFlags.ByteOrderDefault, dataProvider, null, false, CGColorRenderingIntent.Default))
                    {
                        image.Dispose();
                        image = null;
                        pixelData = null;
                        return UIImage.FromImage(cgImage, 0, orientation);
                    }
                }
            }
        }
    }
}
