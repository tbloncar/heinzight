
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

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

			continueButton.TouchUpInside += (sender, e) => {
				NavigationController.PushViewController(new AgeSelectionViewController(), true);
			};

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

