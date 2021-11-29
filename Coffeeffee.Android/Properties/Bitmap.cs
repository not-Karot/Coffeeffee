using System;
using System.Runtime.InteropServices;
using Android.Graphics;
using Coffeeffee.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(IBitmap<Android.Graphics.Bitmap>))]
namespace Coffeeffee.Droid.Properties
{
    public class Bitmap : IBitmap<Android.Graphics.Bitmap>
    {
        const byte bytesPerPixel = 4;
        readonly int height;
        readonly int width;
        byte[] pixelData;
        Android.Graphics.Bitmap bitmap;
        string photoFile;

        public Bitmap(string photo)
        {
            photoFile = photo;
            var options = new BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };

            // Bitmap will be null because InJustDecodeBounds = true
            bitmap = BitmapFactory.DecodeFile(photoFile, options);
            width = options.OutWidth;
            height = options.OutHeight;
        }

        public void ToPixelArray()
        {
            bitmap = BitmapFactory.DecodeFile(photoFile);

            int size = width * height * bytesPerPixel;
            pixelData = new byte[size];
            var byteBuffer = Java.Nio.ByteBuffer.AllocateDirect(size);
            bitmap.CopyPixelsToBuffer(byteBuffer);
            Marshal.Copy(byteBuffer.GetDirectBufferAddress(), pixelData, 0, size);
            byteBuffer.Dispose();
        }

        public void TransformImage(Func<byte, byte, byte, double> pixelOperation)
        {
            byte r, g, b;

            try
            {
                // Pixel data order is RGBA
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

        public Android.Graphics.Bitmap ToImage()
        {
            var byteBuffer = Java.Nio.ByteBuffer.AllocateDirect(width * height * bytesPerPixel);
            Marshal.Copy(pixelData, 0, byteBuffer.GetDirectBufferAddress(), width * height * bytesPerPixel);
            bitmap.CopyPixelsFromBuffer(byteBuffer);
            byteBuffer.Dispose();
            return bitmap;
        }

        public void Dispose()
        {
            if (bitmap != null)
            {
                bitmap.Recycle();
                bitmap.Dispose();
                bitmap = null;
            }
            pixelData = null;
        }
    }
}
