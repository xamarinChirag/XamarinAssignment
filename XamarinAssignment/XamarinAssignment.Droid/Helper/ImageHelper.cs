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

namespace XamarinAssignment.Droid.Helper
{
   public static class ImageHelper
    {
        static Dictionary<int, string> urlToImageMap = new Dictionary<int, string>();
        public static void SetImage(byte[] imageBytes,int listingID, ImageView downloadedImageView,int isOrignal = 50 )
        {
            if (!urlToImageMap.ContainsKey(listingID))
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string localFilename = listingID + ".jpg";
                string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

                var localImage = new Java.IO.File(localPath);
                if (localImage.Exists())
                {
                    setPic(localImage.AbsolutePath, downloadedImageView, isOrignal);
                    urlToImageMap.Add(listingID, localImage.AbsolutePath);
                    //    var teamBitmap = BitmapFactory.DecodeFile(localImage.AbsolutePath,BitmapFactory.Options.);
                    //    teamBitmap.
                    //    downloadedImageView.SetImageBitmap(teamBitmap);
                }
            }
            else
            {
                setPic(urlToImageMap[listingID], downloadedImageView, isOrignal);

            }
}
        private static void setPic(String imagePath, ImageView destination, int targetScale)
        {
            
                int targetW = targetScale;
                int targetH = targetScale;
                // Get the dimensions of the bitmap
                BitmapFactory.Options bmOptions = new BitmapFactory.Options();
                bmOptions.InJustDecodeBounds = true;
                BitmapFactory.DecodeFile(imagePath, bmOptions);
                int photoW = bmOptions.OutWidth;
                int photoH = bmOptions.OutHeight;

                // Determine how much to scale down the image
                int scaleFactor = Math.Min(photoW / targetW, photoH / targetH);

                // Decode the image file into a Bitmap sized to fill the View
                bmOptions.InJustDecodeBounds = false;
                bmOptions.InSampleSize = scaleFactor;
                bmOptions.InPurgeable = true;

            
            Bitmap bitmap = BitmapFactory.DecodeFile(imagePath, bmOptions);
            Bitmap result = Bitmap.CreateScaledBitmap(bitmap,
                        targetScale, targetScale, false);
            destination.SetImageBitmap(result);
            
            //else
            //{
            //    var teamBitmap = BitmapFactory.DecodeFile(imagePath);
            //    destination.SetImageBitmap(teamBitmap);
            //}
        }
    }
}