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
using Cirrious.CrossCore;
using Plugin.Connectivity;

namespace XamarinAssignment.Droid
{
    [Activity(Label = "PropertyDetailActivity")]
    public class PropertyDetailActivity : Activity
    {
        #region Fields
        IPropertyMangager propertyManager;
        PropertyDetail propertydetail;
        ProgressDialog progress;
        #endregion

        #region Methods
        /// <summary>
        /// OnCreate
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected async  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true);
            //propertyManager = TinyIoC.TinyIoCContainer.Current.Resolve<IPropertyMangager>();
            propertyManager = Mvx.GetSingleton<IPropertyMangager>();

            // propertyManager = new PropertyMangager();
            int listingID = Intent.GetIntExtra("ListingID", 0);
            if (listingID > 0)
            {
                propertydetail = await propertyManager.GetItemAsync(listingID.ToString());
            }
            SetContentView(Resource.Layout.PropertyDetailView);
            if(propertydetail != null)
                BindFields();

            if (CrossConnectivity.Current.IsConnected)
                SQLLiteHelper.InsertPropertyDetails(propertydetail);

            if (progress != null)
                progress.Hide();
        }

        /// <summary>
        /// BindFields
        /// </summary>
        private void BindFields()
        {
            var textViewAddress = FindViewById<TextView>(Resource.Id.AddressText);
            var textViewBeds = FindViewById<TextView>(Resource.Id.BedsText);
            var textViewBaths = FindViewById<TextView>(Resource.Id.BathsText);
            var textEstimatedValue = FindViewById<TextView>(Resource.Id.EstimatedValueText);
            var textChangeOverLastYear = FindViewById<TextView>(Resource.Id.ChangeOverLastYearText);
            var textFeatures = FindViewById<TextView>(Resource.Id.FeaturesText);

            ImageView downloadedImageView = FindViewById<ImageView>(Resource.Id.DownloadedImageView);
            // byte[] imageBytes = null;
            // Task.Run(async () =>
            // {
            //     imageBytes = await propertyManager.GetImageAsync(propertydetail.Image);
            // }
            //).GetAwaiter().GetResult();

            //// ImageHelper.SetImage(imageBytes, propertydetail.ListingID, downloadedImageView, 200);
            ImageHelper.SetImage(propertyManager, propertydetail.ListingID, propertydetail.Image, downloadedImageView);

            textViewAddress.Text = propertydetail.Address;
            textViewBeds.Text = Convert.ToString(propertydetail.Beds);
            textViewBaths.Text = Convert.ToString(propertydetail.Baths);
            textEstimatedValue.Text = "$" + propertydetail.EstimatedValue;
            textChangeOverLastYear.Text = Convert.ToDouble(propertydetail.ChangeOverLastYear).ToString();
            if (Convert.ToDouble(propertydetail.ChangeOverLastYear) < 0)
                textChangeOverLastYear.SetTextColor(Color.Red);
            textFeatures.Text = propertydetail.Features;
        }
        #endregion
    }
}