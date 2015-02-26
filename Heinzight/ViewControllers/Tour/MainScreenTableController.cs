
using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using Heinzight.Core;

namespace Heinzight
{
	public partial class MainScreenTableController : UIViewController
	{
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
			contentTableView.Source = new DisplayListTableViewSource (CurrentUser.Instance.Displays);
			contentTableView.AllowsSelection = false;
			contentTableView.EstimatedRowHeight = 350;
			contentTableView.RowHeight = UITableView.AutomaticDimension;
			contentTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			contentTableView.ReloadData ();
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

