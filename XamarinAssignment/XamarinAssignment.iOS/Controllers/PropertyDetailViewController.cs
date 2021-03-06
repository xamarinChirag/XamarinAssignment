using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using XamarinAssignment.ServiceClient;
using XamarinAssignment.Model;
using System.Threading.Tasks;
using XamarinAssignment.iOS.Helper;
using Cirrious.CrossCore;

namespace XamarinAssignment.iOS
{
	partial class PropertyDetailViewController : UITableViewController
	{
        #region Fields
        int currentPropertyId;
        IPropertyMangager propertyManager;
        PropertyDetail propertyDetail;
        #endregion

        #region Constructor
        public PropertyDetailViewController (IntPtr handle) : base (handle)
		{
            // propertyManager = TinyIoC.TinyIoCContainer.Current.Resolve<IPropertyMangager>();
            propertyManager = Mvx.GetSingleton<IPropertyMangager>();
        }
        #endregion

        #region Methods

        public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
		}

        public  override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            propertyManager = new PropertyMangager();
            if (currentPropertyId > 0)
            {
                propertyDetail = propertyManager.GetItemAsync(currentPropertyId.ToString()).Result;

                byte[] imageBytes = null;
                imageBytes =  propertyManager.GetImageAsync(propertyDetail.Image).Result;

                //ImageHelper.SetImage(imageBytes, propertyDetail.ListingID, PropertyImage, 150);
                ImageHelper.SetImage(propertyManager, propertyDetail.ListingID, propertyDetail.Image, PropertyImage);

                AddressLabel.Text = propertyDetail.Address;
                BedsLabel.Text = string.Format("Beds: {0}", propertyDetail.Beds);
                BathsLabel.Text = string.Format(", Baths: {0}", propertyDetail.Baths);
                EstimatedValueLabel.Text = string.Format(", {0:C}, ", propertyDetail.EstimatedValue);
                RateChangeLabel.Text = string.Format("{0}%", Convert.ToString(propertyDetail.ChangeOverLastYear));
                FeatureText.Text = propertyDetail.Features;
                if (Convert.ToDouble(propertyDetail.ChangeOverLastYear) < 0)
                    RateChangeLabel.TextColor = UIColor.Red;
            }
           
        }

        /// <summary>
        /// // this will be called before the view is displayed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="id"></param>
        public void SetTask (PropertyViewController d, int id) {
            currentPropertyId = id;
        }

        #endregion

    }
}
