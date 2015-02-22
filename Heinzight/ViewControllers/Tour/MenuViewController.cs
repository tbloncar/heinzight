
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

			var navCtrl = new UINavigationController ();
			var nav = new UINavigationBar ();
			nav.BarTintColor = UIColor.FromRGB (167, 49, 63);
			navCtrl.Title = "";
			navCtrl.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;

			var table = new UITableView(new RectangleF(0,50, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height)); 
			string[] configItems = new string[] {"Edit User Information", "Become a Member"};
			table.Source = new TableSource(configItems);
			Add (table);
			System.Console.WriteLine (navCtrl);
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
	}
}

