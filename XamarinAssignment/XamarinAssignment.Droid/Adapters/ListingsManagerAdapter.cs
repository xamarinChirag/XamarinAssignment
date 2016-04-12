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
using XamarinAssignment.Model;
using XamarinAssignment.ServiceClient;
using System.IO;
using Android.Graphics;
using System.Threading.Tasks;
using XamarinAssignment.Droid.Helper;

namespace XamarinAssignment.Droid
{
    class ListingsManagerAdapter : BaseAdapter<Listing>
    {
        Context context;
        int layoutResourceId;
        ListingMangager listingManager;
        List<Listing> listingCollection;
       
        public ListingsManagerAdapter(Context context, 
            int layoutResourceId, List<Listing> listingCollection)
        {
            listingManager = new ListingMangager();
            this.context = context;
            this.layoutResourceId = layoutResourceId;
            this.listingCollection = listingCollection;
        }

        public override Listing this[int position]
        {
           get { return listingCollection[position]; }
        }

        public override int Count
        {
            get { return listingCollection.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                LayoutInflater inflater =
                    context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(layoutResourceId, null);
            }

            ImageView downloadedImageView = view.FindViewById<ImageView>(Resource.Id.DownloadedImageView);
            byte[] imageBytes = null;
            Task.Run(async () =>
            {
                 imageBytes = await listingManager.GetImageAsync(this[position].image);
            }
           ).GetAwaiter().GetResult();

            ImageHelper.SetImage(imageBytes, this[position].listingID, downloadedImageView);

            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //string localFilename = this[position].listingID +  ".jpg";
            //string localPath = System.IO.Path.Combine(documentsPath, localFilename);
            //File.WriteAllBytes(localPath, imageBytes); // writes to local storage   


            //var localImage = new Java.IO.File(localPath);
            //if (localImage.Exists())
            //{
            //    setPic(localImage.AbsolutePath, downloadedImageView);
            ////    var teamBitmap = BitmapFactory.DecodeFile(localImage.AbsolutePath,BitmapFactory.Options.);
            ////    teamBitmap.
            ////    downloadedImageView.SetImageBitmap(teamBitmap);
            //}

            
            TextView textViewAddress = view.FindViewById<TextView>(Resource.Id.AddressText);
            textViewAddress.Text = this[position].address;

            TextView textViewBeds = view.FindViewById<TextView>(Resource.Id.BedsText);
            textViewBeds.Text = Convert.ToString(this[position].beds);

            TextView textBaths = view.FindViewById<TextView>(Resource.Id.BathsText);
            textBaths.Text = Convert.ToString(this[position].baths);

            return view;
        }

       
    }
}