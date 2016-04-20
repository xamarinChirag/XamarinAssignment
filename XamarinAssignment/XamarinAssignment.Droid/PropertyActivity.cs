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
using XamarinAssignment.Infrastructure.CrossCuttings;
using Cirrious.CrossCore;
using Plugin.Connectivity;

namespace XamarinAssignment.Droid
{
	[Activity (Label = "XamarinAssignment.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class PropertyActivity : Activity
	{
        #region Fields
        ListView propertylisttingsView;
        PropertyListingsManagerAdapter listingAdapter;
        List<Property> propertylistings;
        IPropertyMangager propertyManager;
        ProgressDialog progress;
        #endregion

        #region Methods
        /// <summary>
        /// OnCreate
        /// </summary>
        /// <param name="bundle"></param>
        protected async override void OnCreate (Bundle bundle)
		{
            SetUpIOC.SetupContainer();
            if(!CrossConnectivity.Current.IsConnected)
                Mvx.RegisterSingleton(new PropertyRepository(new SQLiteInfoMonodroid()));

            base.OnCreate (bundle);

            propertyManager = Mvx.GetSingleton<IPropertyMangager>();
            //propertyManager = new PropertyMangager();
            SetContentView (Resource.Layout.PropertyViewMain);

            propertylisttingsView = FindViewById<ListView>(Resource.Id.PropertylisttingsView);
            propertylisttingsView.SetItemChecked(0, true);
            propertylisttingsView.ItemClick += ListtingsView_ItemClick;
        }

        /// <summary>
        /// ListtingsView_ItemClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListtingsView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listingDetails = new Intent(this, typeof(PropertyDetailActivity));
            listingDetails.PutExtra("ListingID", propertylistings[e.Position].ListingID);
            StartActivity(listingDetails);

        }

        /// <summary>
        /// OnResume
        /// </summary>
        protected async override void OnResume()
        {
            try
            {
                base.OnResume();
                // show the loading overlay on the UI thread
                progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true);

                //listings = SQLLightCachingHelper.GetProperties().Result;
                propertylistings = await propertyManager.GetItemsAsync();
             
                // create our adapter
                listingAdapter = new PropertyListingsManagerAdapter(this,
                        Resource.Layout.CustomLayoutListingView,
                        propertylistings);

                propertylisttingsView = FindViewById<ListView>(Resource.Id.PropertylisttingsView);
                //Hook up our adapter to our ListView
                propertylisttingsView.Adapter = listingAdapter;
                if (CrossConnectivity.Current.IsConnected)
                    SQLLiteHelper.InsertProperty(propertylistings);

                if (progress != null)
                    progress.Hide();
            }
            catch
            {

            }

        }

        #endregion

    }
}


