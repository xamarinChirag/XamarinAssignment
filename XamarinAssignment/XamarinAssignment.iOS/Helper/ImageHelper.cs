using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.IO;
using UIKit;

namespace XamarinAssignment.iOS.Helper
{
   public static class ImageHelper
    {
        static Dictionary<int, String> urlToImageMap = new Dictionary<int, String>();
        public static void SetImage(byte[] imageBytes,int listingID, UIImageView downloadedImageView,int isOrignal = 50 )
        {

            if (!urlToImageMap.ContainsKey(listingID))
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string localFilename = listingID + ".jpg";
                string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

                downloadedImageView.Image = UIImage.FromFile(localPath);
                urlToImageMap.Add(listingID, localPath);
            }
            else
            {
                downloadedImageView.Image = UIImage.FromFile(urlToImageMap[listingID]);
            }
        }
        //private static void setPic(String imagePath, ImageView destination, int targetScale)
        //{
            
        //        int targetW = targetScale;
        //        int targetH = targetScale;
        //        // Get the dimensions of the bitmap
        //        BitmapFactory.Options bmOptions = new BitmapFactory.Options();
        //        bmOptions.InJustDecodeBounds = true;
        //        BitmapFactory.DecodeFile(imagePath, bmOptions);
        //        int photoW = bmOptions.OutWidth;
        //        int photoH = bmOptions.OutHeight;

        //        // Determine how much to scale down the image
        //        int scaleFactor = Math.Min(photoW / targetW, photoH / targetH);

        //        // Decode the image file into a Bitmap sized to fill the View
        //        bmOptions.InJustDecodeBounds = false;
        //        bmOptions.InSampleSize = scaleFactor;
        //        bmOptions.InPurgeable = true;

            
        //    Bitmap bitmap = BitmapFactory.DecodeFile(imagePath, bmOptions);
        //    Bitmap result = Bitmap.CreateScaledBitmap(bitmap,
        //                targetScale, targetScale, false);
        //    destination.SetImageBitmap(result);
            
        //    //else
        //    //{
        //    //    var teamBitmap = BitmapFactory.DecodeFile(imagePath);
        //    //    destination.SetImageBitmap(teamBitmap);
        //    //}
        //}
    }
}