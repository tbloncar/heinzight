
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Heinzight
{
	public class ExhibitCardViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("ExhibitCardViewCell");

		[Export ("initWithFrame:")]
		public ExhibitCardViewCell (RectangleF frame) : base (frame)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			BackgroundColor = UIColor.Cyan;
		}
	}
}

