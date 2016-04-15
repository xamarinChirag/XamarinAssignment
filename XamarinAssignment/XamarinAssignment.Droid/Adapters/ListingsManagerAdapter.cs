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
    class ListingsManagerAdapter : BaseAdapter<Property>
    {
        Context context;
        int layoutResourceId;
        PropertyMangager listingManager;
        List<Property> listingCollection;
       
        public ListingsManagerAdapter(Context context, 
            int layoutResourceId, List<Property> listingCollection)
        {
            listingManager = new PropertyMangager();
            this.context = context;
            this.layoutResourceId = layoutResourceId;
            this.listingCollection = listingCollection;
        }

        public override Property this[int position]
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
                 imageBytes = await listingManager.GetImageAsync(this[position].Image);
            }
           ).GetAwaiter().GetResult();

            ImageHelper.SetImage(imageBytes, this[position].ListingID, downloadedImageView);
            
            TextView textViewAddress = view.FindViewById<TextView>(Resource.Id.AddressText);
            textViewAddress.Text = this[position].Address;

            TextView textViewBeds = view.FindViewById<TextView>(Resource.Id.BedsText);
            textViewBeds.Text = Convert.ToString(this[position].Beds);

            TextView textBaths = view.FindViewById<TextView>(Resource.Id.BathsText);
            textBaths.Text = Convert.ToString(this[position].Baths);

            return view;
        }

       
    }
}