
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public partial class MenuViewController : UIViewController
	{
		public MenuViewController () : base ("MenuViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UITapGestureRecognizer doubletap =  new UITapGestureRecognizer(OnDoubleTap) {
				NumberOfTapsRequired = 2 // double tap
			};

			var table = new UITableView(new RectangleF(0,50, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)); 
			string[] configItems = new string[] {"Edit User Information", "Become a Member"};
			table.Source = new TableSource(configItems);
			table.AddGestureRecognizer (doubletap);
			Add (table);




		}

		public class TableSource : UITableViewSource {
			string[] tableItems;
			string cellIdentifier = "TableCell";
			public TableSource (string[] items)
			{
				tableItems = items;
			}
			public override int RowsInSection (UITableView tableview, int section)
			{
				return tableItems.Length;
			}
			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
				// if there are no cells to reuse, create a new one
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				cell.TextLabel.Text = tableItems[indexPath.Row];
				return cell;
			}
		}

		private void OnDoubleTap (UIGestureRecognizer gesture) {
			PresentingViewController.DismissViewController(true, null);
		}
	}
}

