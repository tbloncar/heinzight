using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Heinzight
{
	public class DisplayListTableViewSource : UITableViewSource
	{
		public DisplayListTableViewSource ()
		{
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 1;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (DisplayListTableViewCell.Key) as DisplayListTableViewCell;
			if(cell == null){
				cell = DisplayListTableViewCell.Create ();
			}
			return cell;
		}

	}
}

