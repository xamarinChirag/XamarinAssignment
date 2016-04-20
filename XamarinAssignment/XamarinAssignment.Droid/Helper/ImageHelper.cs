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
        #region  Fields
        static Dictionary<int, string> urlToImageMap = new Dictionary<int, string>();
        #endregion

        #region Methods

        /// <summary>
        /// Download the image from the url and save it to local storage for reuse
        /// </summary>
        /// <param name="propertyManager"></param>
        /// <param name="listingID"></param>
        /// <param name="imageName"></param>
        /// <param name="downloadedImageView"></param>
        /// <param name="isOrignal"></param>
        public static void SetImage(IPropertyMangager propertyManager,int listingID, string imageName, ImageView downloadedImageView, int isOrignal = 100)
        {
            byte[] imageBytes = null;

            if (!urlToImageMap.ContainsKey(listingID))
            {

                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string localFilename = listingID + ".jpg";
                string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                if (!File.Exists(localPath))
                {
                    Task.Run(async () =>
                    {
                        imageBytes = await propertyManager.GetImageAsync(imageName);
                    }
                     ).GetAwaiter().GetResult();

                    if (imageBytes != null && imageBytes.Length >0)
                        File.WriteAllBytes(localPath, imageBytes); // writes to local storage   
                }

                var localImage = new Java.IO.File(localPath);
                if (localImage.Exists())
                {
                    SetPic(localImage.AbsolutePath, downloadedImageView, isOrignal);
                    urlToImageMap.Add(listingID, localImage.AbsolutePath);
                }
            }
            else
            {
                SetPic(urlToImageMap[listingID], downloadedImageView, isOrignal);

            }
        }

        /// <summary>
        /// Scaling the image for proper resolution
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="destination"></param>
        /// <param name="targetScale"></param>
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

        #endregion
    }
}