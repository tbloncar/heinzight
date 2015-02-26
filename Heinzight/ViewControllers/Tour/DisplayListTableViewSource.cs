using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Heinzight.Core.ORM;

namespace Heinzight
{
	public class DisplayListTableViewSource : UITableViewSource
	{
		List<Display> displayList;

		public DisplayListTableViewSource (List<Display> displays)
		{
			displayList = displays;
			var display = new Display {
				Name = "Andrew Carnegie",
			};
			display.Exhibit = new Exhibit {
				Name = "Pittsburgh Important People"
			};
			displayList.Add (display);
			displayList.Add (display);

		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return displayList.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (DisplayListTableViewCell.Key) as DisplayListTableViewCell;
			if(cell == null){
				cell = DisplayListTableViewCell.Create ();
			}

			cell.DisplayLabel.Text = displayList [indexPath.Row].Name;
			cell.ExhibitLabel.Text = displayList [indexPath.Row].Exhibit.Name;
//			cell.Layer.MasksToBounds = false;
//			cell.Layer.ShadowOffset = new System.Drawing.SizeF (15, 0);
//			cell.Layer.ShadowOpacity = 0.5f;
//			cell.Layer.ShadowRadius = 5;
//			cell.Layer.ShadowPath = UIBezierPath.FromRect (cell.Bounds).CGPath;
			return cell;
		}

	}
}

