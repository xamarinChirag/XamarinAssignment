// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinAssignment.iOS
{
	[Register ("PropertyViewCell")]
	partial class PropertyViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AddressLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel BedsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView PropertyImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddressLabel != null) {
				AddressLabel.Dispose ();
				AddressLabel = null;
			}
			if (BedsLabel != null) {
				BedsLabel.Dispose ();
				BedsLabel = null;
			}
			if (PropertyImage != null) {
				PropertyImage.Dispose ();
				PropertyImage = null;
			}
		}
	}
}
