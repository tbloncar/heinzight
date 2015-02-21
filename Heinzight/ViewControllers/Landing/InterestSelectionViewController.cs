
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Heinzight.Core;
using Heinzight.Core.ORM;

//using SQLite.Net;

namespace Heinzight
{
	public partial class InterestSelectionViewController : UIViewController
	{
		const int PADDING_HEIGHT = 10;

		public InterestSelectionViewController () : base ("InterestSelectionViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			List<Interest> interests;
			using (var conn = Db.Instance.GetConnection ()) {
				interests = conn.Table<Interest> ().ToList();
			}

			var lastY = 0f;
			foreach (var interest in interests) {
				var scrollViewFrame = interestsScrollView.Frame;
				var frame = new RectangleF (
					(scrollViewFrame.Width / 4), 
					lastY + PADDING_HEIGHT, 
					(scrollViewFrame.Width / 4) * 3,
					80
				);
				var interestButton = new UIButton (frame);
				interestButton.SetTitle (interest.Name, UIControlState.Normal);
				interestButton.Layer.BorderColor = UIColor.DarkGray.CGColor;
				interestButton.Layer.CornerRadius = 40;
				interestsScrollView.Add (interestButton);

				lastY += frame.Height + PADDING_HEIGHT;
			}

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

