using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinAssignment.iOS
{
	partial class PropertyViewCell : UITableViewCell
	{


        #region  Properties
        public UIImageView Image
        {
            get { return PropertyImage; }
            set { PropertyImage = value; }
        }

        public string Address
        {
            get { return AddressLabel.Text; }
            set { AddressLabel.Text = value; }
        }

        public string Beds
        {
            get { return BedsLabel.Text; }
            set { BedsLabel.Text = value; }
        }
        #endregion
        public PropertyViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
