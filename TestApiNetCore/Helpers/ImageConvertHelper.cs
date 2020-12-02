using System;
using System.Drawing;
using System.IO;

namespace FaxiApiNetCore.Helpers
{
    public class ImageConvertHelper
    {
        public static string ImageToBase64(string path)
        {
            using (var image = Image.FromFile(path))
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    return Convert.ToBase64String(m.ToArray());
                }
            }
        }
        public static Image Base64ToImage(string base64String)
        {
            var imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            return Image.FromStream(ms, true);
        }

        public static byte[] Base64ToByteArray(string base64String)
        {
            var imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);

            return imageBytes;
        }
    }
}
