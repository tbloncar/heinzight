
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

			var v = new DisplayView (10f, "Title", "Header", UIImage.FromBundle("garden-logo"));

			NavigationController.NavigationBarHidden = false;


			var menuButton = new UIBarButtonItem (UIImage.FromBundle ("menu"), UIBarButtonItemStyle.Plain, (s, e) => {
				ShowMenu();
			});
			NavigationItem.RightBarButtonItem = menuButton;

			var mapButton = new UIBarButtonItem (UIImage.FromBundle ("map"), UIBarButtonItemStyle.Plain, (s, e) => {
				ShowMap();
			});
			NavigationItem.LeftBarButtonItem = mapButton;

//			var menuButton = new UIBarButtonItem ("menu", UIBarButtonItemStyle.Plain, (s, e) => {
//				ShowMenu();
//			});

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
						var dv = new DisplayView (y, display.Name, display.Exhibit.Name, UIImage.FromBundle(display.ImageUrl));
						
						y += dv.Frame.Height + 10f;

						scrollView.Add(dv);
					}
				}
			};
		}

		void ShowMenu()
		{
			PresentViewController (new MenuViewController (), true, null);
		}

		void ShowMap()
		{
			PresentViewController (new MapViewController (), true, null);
		}
	}
}

