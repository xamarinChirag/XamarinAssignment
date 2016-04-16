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
        IPropertyMangager propertyManager;
        PropertyDetail detail;
        ProgressDialog progress;
        protected async  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
            propertyManager = TinyIoC.TinyIoCContainer.Current.Resolve<IPropertyMangager>();
            //propertyManager = new PropertyMangager();
            int listingID = Intent.GetIntExtra("ListingID", 0);
            if (listingID > 0)
            {
                detail = await propertyManager.GetItemAsync(listingID.ToString());
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
                imageBytes = await propertyManager.GetImageAsync(detail.Image);
            }
           ).GetAwaiter().GetResult();


            ImageHelper.SetImage(imageBytes, detail.ListingID, downloadedImageView,150);
            textViewAddress.Text = detail.Address;
            textViewBeds.Text = Convert.ToString(detail.Beds);
            textViewBaths.Text = Convert.ToString(detail.Baths);
            textEstimatedValue.Text = "$" + detail.EstimatedValue;
            textChangeOverLastYear.Text = Convert.ToDouble(detail.ChangeOverLastYear).ToString();
            if (Convert.ToDouble(detail.ChangeOverLastYear) < 0)
                textChangeOverLastYear.SetTextColor(Color.Red);
            textFeatures.Text = detail.Features;

            if (progress != null)
                progress.Hide();
        }
    }
}