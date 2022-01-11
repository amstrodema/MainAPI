using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MainAPI.Services
{
    public class ImageEditService
    {
        public string ResizeImageFromString(string ImgString, int Width, int Height)
        {
            if (!string.IsNullOrEmpty(ImgString))
            {
                byte[] image = Convert.FromBase64String(ImgString);

                MemoryStream imageValue = new MemoryStream();
                ImageBuilder.Current.Build(
                   new ImageJob(image, imageValue, new Instructions("maxwidth=" + Width + "&maxheight=" + Height + "&format=jpg"), false, true)
                   );

                return Convert.ToBase64String(imageValue.ToArray());
            }
            return default;
        }

        //public static string ResizeImageFromStream(HttpPostedFileBase image, int Width, int Height)
        //{

        //    if (image != null)
        //    {
        //        image.InputStream.Seek(0, SeekOrigin.Begin);

        //        MemoryStream imageValue = new MemoryStream();
        //        ImageBuilder.Current.Build(
        //           new ImageJob(image.InputStream, imageValue, new Instructions("maxwidth=" + Width + "&maxheight=" + Height + "&format=jpg"), false, true)
        //           );

        //        return Convert.ToBase64String(imageValue.ToArray());
        //    }
        //    return default;
        //}
    }

}
