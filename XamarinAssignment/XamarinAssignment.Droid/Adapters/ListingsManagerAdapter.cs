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

namespace XamarinAssignment.Droid
{
    class ListingsManagerAdapter : BaseAdapter<Listing>
    {
        Context context;
        int layoutResourceId;
        List<Listing> listingCollection;

        public ListingsManagerAdapter(Context context, 
            int layoutResourceId, List<Listing> listingCollection)
        {
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
            //var view = (convertView ??
            //        context.layout.Inflate(
            //        Resource.Layout.CustomLayoutListingView,
            //        parent,
            //        false)) as LinearLayout;


            TextView textViewAddress = view.FindViewById<TextView>(Resource.Id.AddressText);
            textViewAddress.Text = this[position].address;

            TextView textViewBeds = view.FindViewById<TextView>(Resource.Id.BedsText);
            textViewBeds.Text = Convert.ToString(this[position].beds);

            return view;
        }
    }
}