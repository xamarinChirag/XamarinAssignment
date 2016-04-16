using System;
using CoreGraphics;
using System.Collections.Generic;

using Foundation;
using UIKit;
using XamarinAssignment.Model;
using XamarinAssignment.ServiceClient;

namespace XamarinAssignment.iOS
{
	public partial class PropertyViewController : UITableViewController
	{
        List<Property> properties;
        IPropertyMangager propertyManager;
        public PropertyViewController (IntPtr handle) : base (handle)
		{
            //listingManager = new PropertyMangager();
            propertyManager = TinyIoC.TinyIoCContainer.Current.Resolve<IPropertyMangager>();

        }

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "DetailSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as PropertyDetailViewController;
				if (navctlr != null) {
					var source = TableView.Source as PropertyTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetTask (this, item.ListingID); 
				}
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public override void ViewWillAppear (bool animated)
		{
            base.ViewWillAppear(animated);

            
            properties = propertyManager.GetItemsAsync().Result;
            // bind every time, to reflect deletion in the Detail view
            TableView.Source = new PropertyTableSource(properties);
            
        }

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

	}
}

