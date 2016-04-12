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
    [Activity(Label = "ListingDetailActivity")]
    public class ListingDetailActivity : Activity
    {
        ListingMangager listingManager;
        ListingDetail detail;
        protected async  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            listingManager = new ListingMangager();
            int listingID = Intent.GetIntExtra("ListingID", 0);
            if (listingID > 0)
            {
                detail = await listingManager.GetItemAsync(listingID.ToString());
            }
            SetContentView(Resource.Layout.ListingDetailView);
            var textViewAddress = FindViewById<TextView>(Resource.Id.AddressText);
            var textViewBeds = FindViewById<TextView>(Resource.Id.BedsText);
            var textViewBaths = FindViewById<TextView>(Resource.Id.BathsText);

            textViewAddress.Text = detail.address;
            textViewBeds.Text = Convert.ToString(detail.beds);
            textViewBaths.Text = Convert.ToString(detail.baths);



        }
    }
}