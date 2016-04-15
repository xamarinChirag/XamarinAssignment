using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinAssignment.Model;
using System.Collections.Generic;
using XamarinAssignment.ServiceClient;
using System.Threading.Tasks;

namespace XamarinAssignment.Droid
{
	[Activity (Label = "XamarinAssignment.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        ListView listtingsView;
        ListingsManagerAdapter listingAdapter;
        List<Property> listings;
        PropertyMangager listingManager;
        ProgressDialog progress;
        protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            listingManager = new PropertyMangager();
            SetContentView (Resource.Layout.Main);
            listtingsView = FindViewById<ListView>(Resource.Id.listtingsView);

            listtingsView.SetItemChecked(0, true);
            listtingsView.ItemClick += ListtingsView_ItemClick; 
        }
        private void ListtingsView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listingDetails = new Intent(this, typeof(ListingDetailActivity));
            listingDetails.PutExtra("ListingID", listings[e.Position].ListingID);
            StartActivity(listingDetails);

        }

        protected async  override void OnResume()
        {
            try
            {
                base.OnResume();

                // show the loading overlay on the UI thread
                progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true);

                listings = await listingManager.GetItemsAsync();
                // create our adapter
                listingAdapter = new ListingsManagerAdapter(this,
                        Resource.Layout.CustomLayoutListingView,
                        listings);
                listtingsView = FindViewById<ListView>(Resource.Id.listtingsView);
                //Hook up our adapter to our ListView
                listtingsView.Adapter = listingAdapter;
                if (progress != null)
                    progress.Hide();
            }
            catch (Exception ex)
            {

            }

        }
    }
}


