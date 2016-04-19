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
using Cirrious.CrossCore;

namespace XamarinAssignment.Droid
{
    class PropertyListingsManagerAdapter : BaseAdapter<Property>
    {

        #region Fields
        Context context;
        int layoutResourceId;
        IPropertyMangager propertyManager;
        List<Property> propertyCollection;
        #endregion

        #region Methods
        public PropertyListingsManagerAdapter(Context context, 
            int layoutResourceId, List<Property> listingCollection)
        {
            //propertyManager = TinyIoC.TinyIoCContainer.Current.Resolve<IPropertyMangager>();
            //propertyManager = new PropertyMangager();

            this.context = context;
            this.layoutResourceId = layoutResourceId;
            this.propertyCollection = listingCollection;

            propertyManager = Mvx.GetSingleton<IPropertyMangager>();

        }

        public override Property this[int position]
        {
           get { return propertyCollection[position]; }
        }

        public override int Count
        {
            get { return propertyCollection.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public  override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                LayoutInflater inflater =
                    context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(layoutResourceId, null);
            }

            ImageView downloadedImageView = view.FindViewById<ImageView>(Resource.Id.DownloadedImageView);
           // byte[] imageBytes = null;

            //imageBytes =  propertyManager.GetImageAsync(this[position].Image).Result;
        
            ImageHelper.SetImage(propertyManager,  this[position].ListingID, this[position].Image,downloadedImageView);

            TextView textViewAddress = view.FindViewById<TextView>(Resource.Id.AddressText);
            textViewAddress.Text = this[position].Address;

            TextView textViewBeds = view.FindViewById<TextView>(Resource.Id.BedsText);
            textViewBeds.Text = Convert.ToString(this[position].Beds);

            TextView textBaths = view.FindViewById<TextView>(Resource.Id.BathsText);
            textBaths.Text = Convert.ToString(this[position].Baths);

            return view;
        }
        #endregion

    }
}