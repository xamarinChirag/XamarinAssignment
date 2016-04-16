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
	[Register ("PropertyDetailViewController")]
	partial class PropertyDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AddressLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel BathsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel BedsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel EstimatedValueLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView FeatureText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView PropertyImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel RateChangeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableDetailView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddressLabel != null) {
				AddressLabel.Dispose ();
				AddressLabel = null;
			}
			if (BathsLabel != null) {
				BathsLabel.Dispose ();
				BathsLabel = null;
			}
			if (BedsLabel != null) {
				BedsLabel.Dispose ();
				BedsLabel = null;
			}
			if (EstimatedValueLabel != null) {
				EstimatedValueLabel.Dispose ();
				EstimatedValueLabel = null;
			}
			if (FeatureText != null) {
				FeatureText.Dispose ();
				FeatureText = null;
			}
			if (PropertyImage != null) {
				PropertyImage.Dispose ();
				PropertyImage = null;
			}
			if (RateChangeLabel != null) {
				RateChangeLabel.Dispose ();
				RateChangeLabel = null;
			}
			if (TableDetailView != null) {
				TableDetailView.Dispose ();
				TableDetailView = null;
			}
		}
	}
}
