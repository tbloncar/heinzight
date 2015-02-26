
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

			FinalizeView ();

			InitBeaconService ();
		}

		void FinalizeView()
		{

		}

		void InitBeaconService()
		{
			var bs = new BeaconService ();
			bs.StartService ();
			
			var userDisplays = CurrentUser.Instance.Displays;
			BeaconManager.Instance.BeaconsUpdated += beaconList => {
				
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

