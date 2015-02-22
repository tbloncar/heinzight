using System;
using System.Drawing;
using MonoTouch.UIKit;
using Heinzight.Core;

namespace Heinzight
{
	public class DisplayView : UIView 
	{

		public IBeaconProximity Proximity { get; set; }

		UILabel titleFrame;
		UILabel headerFrame;
		UIImageView imageView;

		public DisplayView (float y, string title, string header, UIImage image)
		{
			Frame = new RectangleF (5, y, 300, 400);
			BackgroundColor = UIColor.White;

			titleFrame = new UILabel (new RectangleF (0, 50, Frame.Width, 30));
			titleFrame.Text = title;
			titleFrame.TextAlignment = UITextAlignment.Center;
			
			headerFrame = new UILabel (new RectangleF (0, 10, Frame.Width, 30));
			headerFrame.Text = header;
			headerFrame.TextAlignment = UITextAlignment.Center;
			
			
			imageView = new UIImageView (new RectangleF (0, 100, Frame.Width, Frame.Width));
			imageView.Image = image;
			AddSubviews (titleFrame, headerFrame, imageView);
			

		}

		public void UpdateView()
		{
		}
	}
}

