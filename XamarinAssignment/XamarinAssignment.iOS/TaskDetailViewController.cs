using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using XamarinAssignment.ServiceClient;
using XamarinAssignment.Model;
using System.Threading.Tasks;

namespace XamarinAssignment.iOS
{
	partial class TaskDetailViewController : UITableViewController
	{
		int currentPropertyId {get;set;}
        PropertyMangager listingManager;
        PropertyDetail detail;
        public TaskDetailViewController (IntPtr handle) : base (handle)
		{
          

        }

		// when displaying, set-up the properties
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            listingManager = new PropertyMangager();
            if (currentPropertyId > 0)
            {
                Task.Run(async () =>
                {
                    detail = await listingManager.GetItemAsync(currentPropertyId.ToString());
                }
                ).GetAwaiter().GetResult();
            }
            //PropertyImage.Image = 
            AddressLabel.Text = detail.Address;
            BedsLabel.Text = string.Format("Beds: {0}", detail.Beds);
            BathLabel.Text = string.Format(",Baths: {0}", detail.Baths);
            EstimatedValueLabel.Text = string.Format(",Baths: {0:C}", detail.EstimatedValue);
            RateChangeLabel.Text = Convert.ToString(detail.ChangeOverLastYear);
            FeatureText.Text = detail.Features;
            if (Convert.ToDouble(detail.ChangeOverLastYear) < 0)
                RateChangeLabel.TextColor = UIColor.Red;
        }

        // this will be called before the view is displayed
        public void SetTask (MasterViewController d, int id) {
            currentPropertyId = id;
        }
	}
}
