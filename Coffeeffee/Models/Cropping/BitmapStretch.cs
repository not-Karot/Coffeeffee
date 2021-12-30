using System;
namespace Coffeeffee.Models.Cropping
{
    public enum BitmapStretch
    {
        None,
        Fill,
        Uniform,
        UniformToFill,
        AspectFit = Uniform,
        AspectFill = UniformToFill
    }
}
