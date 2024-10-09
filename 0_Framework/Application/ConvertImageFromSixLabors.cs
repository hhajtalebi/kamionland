using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using System.IO;
using SixLabors.ImageSharp.Processing;

namespace _0_Framework.Application
{
    public static class ConvertImageFromSixLabors
    {

        public static void Image_resize(string output, int width, int height, IFormFile file, string fileName)
        {

            var filename = fileName;
            var outPath = output;
            using (Image img = Image.Load(file.OpenReadStream()))
            {
                img.Mutate(r => r.Resize(width, height));
                img.Save(outPath);
            }
        }
    }
}
