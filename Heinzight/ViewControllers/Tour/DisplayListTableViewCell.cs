
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public partial class DisplayListTableViewCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("DisplayListTableViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("DisplayListTableViewCell");

		public DisplayListTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public static DisplayListTableViewCell Create ()
		{
			return (DisplayListTableViewCell)Nib.Instantiate (null, null) [0];
		}
	}
}

