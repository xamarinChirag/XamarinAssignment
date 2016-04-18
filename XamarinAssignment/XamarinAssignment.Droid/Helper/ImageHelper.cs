using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Threading.Tasks;
using System.IO;
using XamarinAssignment.ServiceClient;
using XamarinAssignment.Model;

namespace XamarinAssignment.Droid.Helper
{
   public static class ImageHelper
    {
        static Dictionary<int, string> urlToImageMap = new Dictionary<int, string>();
        public static void SetImage(IPropertyMangager propertyManager, Property property, ImageView downloadedImageView, int isOrignal = 100)
        {
            byte[] imageBytes = null;

            if (!urlToImageMap.ContainsKey(property.ListingID))
            {
                Task.Run(async () =>
                {
                    imageBytes = await propertyManager.GetImageAsync(property.Image);

                }
                ).ConfigureAwait(false);

                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string localFilename = property.ListingID + ".jpg";
                string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                if (!File.Exists(localPath))
                    File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

                var localImage = new Java.IO.File(localPath);
                if (localImage.Exists())
                {
                    SetPic(localImage.AbsolutePath, downloadedImageView, isOrignal);
                    urlToImageMap.Add(property.ListingID, localImage.AbsolutePath);
                }
            }
            else
            {
                SetPic(urlToImageMap[property.ListingID], downloadedImageView, isOrignal);

            }
        }
        private static void SetPic(String imagePath, ImageView destination, int targetScale)
        {
            
                //int targetW = targetScale;
                //int targetH = targetScale;
                //// Get the dimensions of the bitmap
                //BitmapFactory.Options bmOptions = new BitmapFactory.Options();
                //bmOptions.InJustDecodeBounds = true;
                //BitmapFactory.DecodeFile(imagePath, bmOptions);
                //int photoW = bmOptions.OutWidth;
                //int photoH = bmOptions.OutHeight;

                //// Determine how much to scale down the image
                //int scaleFactor = Math.Min(photoW / targetW, photoH / targetH);

                //// Decode the image file into a Bitmap sized to fill the View
                //bmOptions.InJustDecodeBounds = false;
                //bmOptions.InSampleSize = scaleFactor;
                //bmOptions.InPurgeable = true;

            
            Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
            //Bitmap result = Bitmap.CreateScaledBitmap(bitmap,
            //            targetScale + 50, targetScale, false);
            //destination.SetImageBitmap(result);
            destination.SetImageBitmap(bitmap);
        }
    }
}