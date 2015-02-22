
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Heinzight.Core;
using Heinzight.Core.ORM;

namespace Heinzight
{
	public partial class MainScreenTableController : UIViewController
	{
		Dictionary<Display, DisplayView> displayViewDictionary = new Dictionary<Display, DisplayView>();

		public MainScreenTableController () : base ("MainScreenTableController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			IBeaconProximity proximity = IBeaconProximity.Immediate;

			var v = new DisplayView (10f, "Andrew Carnegie", "Pittsburgh: A Tradition of Innovation", UIImage.FromBundle("garden-logo"), proximity);

			NavigationController.NavigationBarHidden = false;


			var menuButton = new UIBarButtonItem (UIImage.FromBundle ("menu"), UIBarButtonItemStyle.Plain, null,  null);
			NavigationItem.RightBarButtonItem = menuButton;

			var mapButton = new UIBarButtonItem (UIImage.FromBundle ("map"), UIBarButtonItemStyle.Plain, null, null );
			NavigationItem.LeftBarButtonItem = mapButton;

			scrollView.Add(v);

			var bs = new BeaconService ();
			bs.StartService ();

			var userDisplays = CurrentUser.Instance.Displays;
			BeaconManager.Instance.BeaconsUpdated += beaconList => {
				var y = 0f;

				foreach (var b in beaconList) {
					var displaysList = userDisplays.Where (d => d.BeaconMajorNum == b.BeaconMajorNum && d.BeaconMinorNum == b.BeaconMinorNum).ToList();
					Console.WriteLine(displaysList.FirstOrDefault(t => true));
					if (!displaysList.Any ())
						continue;

					var display = displaysList.First ();
					if (display != null)
					{
						IBeaconProximity myProximity = IBeaconProximity.Immediate;
						var dv = new DisplayView (y, display.Name, display.Exhibit.Name, UIImage.FromBundle(display.FeaturedImagePath),myProximity);
						
						y += dv.Frame.Height + 10f;

						scrollView.Add(dv);
					}
				}
			};
		}

		void ShowMenu()
		{
			PresentViewController (new UIViewController (), true, null);
		}

		void ShowMap()
		{
			PresentViewController (new MapViewController (), true, null);
		}
	}
}

