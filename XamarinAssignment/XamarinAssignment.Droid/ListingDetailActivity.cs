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
using System.Threading.Tasks;
using XamarinAssignment.Droid.Helper;
using Android.Graphics;

namespace XamarinAssignment.Droid
{
    [Activity(Label = "ListingDetailActivity")]
    public class ListingDetailActivity : Activity
    {
        ListingMangager listingManager;
        ListingDetail detail;
        ProgressDialog progress;
        protected async  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
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
            var textEstimatedValue = FindViewById<TextView>(Resource.Id.EstimatedValueText); 
            var textChangeOverLastYear = FindViewById<TextView>(Resource.Id.ChangeOverLastYearText);
            var textFeatures = FindViewById<TextView>(Resource.Id.FeaturesText); 

             ImageView downloadedImageView = FindViewById<ImageView>(Resource.Id.DownloadedImageView);
            byte[] imageBytes = null;
            Task.Run(async () =>
            {
                imageBytes = await listingManager.GetImageAsync(detail.image);
            }
           ).GetAwaiter().GetResult();

            ImageHelper.SetImage(imageBytes, detail.listingID, downloadedImageView,150);
            textViewAddress.Text = detail.address;
            textViewBeds.Text = Convert.ToString(detail.beds);
            textViewBaths.Text = Convert.ToString(detail.baths);
            textEstimatedValue.Text = "$" + detail.estimatedValue;
            textChangeOverLastYear.Text = Convert.ToDouble(detail.changeOverLastYear).ToString();
            if (Convert.ToDouble(detail.changeOverLastYear) < 0)
                textChangeOverLastYear.SetTextColor(Color.Red);
            textFeatures.Text = detail.features;

            if (progress != null)
                progress.Hide();
        }
    }
}