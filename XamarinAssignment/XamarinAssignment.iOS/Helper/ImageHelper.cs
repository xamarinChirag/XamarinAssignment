using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.IO;
using UIKit;
using XamarinAssignment.ServiceClient;
using XamarinAssignment.Model;

namespace XamarinAssignment.iOS.Helper
{
   public static class ImageHelper
    {
        static Dictionary<int, string> urlToImageMap = new Dictionary<int, string>();
        public static void SetImage(IPropertyMangager propertyManager, Property property, UIImageView downloadedImageView, int isOrignal = 50)
        {

            byte[] imageBytes = null;

            if (!urlToImageMap.ContainsKey(property.ListingID))
            {
                Task.Run(async () =>
                {
                    imageBytes = await propertyManager.GetImageAsync(property.Image);

                }
                ).ConfigureAwait(false);


                //imageBytes = propertyManager.GetImageAsync(propertyitem.Image).Result
                if (!urlToImageMap.ContainsKey(property.ListingID))
                {
                    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string localFilename = property.ListingID + ".jpg";
                    string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                    if (!File.Exists(localPath))
                        File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

                    downloadedImageView.Image = UIImage.FromFile(localPath);
                    urlToImageMap.Add(property.ListingID, localPath);
                }
                else
                {
                    downloadedImageView.Image = UIImage.FromFile(urlToImageMap[property.ListingID]);
                }
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