using System;
using System.Device.Location;

using MonoTouch.UIKit;

using Heinzight.Core;
using Heinzight.Core.DAO;

namespace Heinzight
{
	public partial class LandingViewController : UIViewController
	{
		public LandingViewController () : base ("LandingViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var nearbyLocations = LocationDAO.GetLocationsByCoordinates (new GeoCoordinate {
				Latitude = 40.4463499,
				Longitude = -79.9925008
			});

			mainLogoImageView.Image = UIImage.FromFile ("heinz-logo.png");
			secondaryLogoImageView.Image = UIImage.FromFile ("garden-logo.png");

			continueButton.Layer.BorderColor = UIColor.White.CGColor;
			continueButton.Layer.BorderWidth = 2.0f;
			continueButton.Layer.CornerRadius = 16;

			continueButton.TouchUpInside += (sender, e) => {
				// Assign the nearest location to the current user
				CurrentUser.Instance.Location = nearbyLocations [0];

				NavigationController.PushViewController (new AgeSelectionViewController (), true);
			};
		}
	}
}

