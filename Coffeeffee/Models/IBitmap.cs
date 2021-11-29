using System;
namespace Coffeeffee.Models
{
    public interface IBitmap<T>
    {
        void ToPixelArray();

        void TransformImage(Func<byte, byte, byte, double> pixelOperation);
        T ToImage();
    }
}