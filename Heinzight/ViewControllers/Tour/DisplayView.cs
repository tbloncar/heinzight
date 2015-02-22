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
		UILabel preProximityLabel;
		UILabel proximityLabel;
		UIView proximityContainer;
		UIImageView imageView;
		UIImageView proximityView;

		public DisplayView (float y, string title, string header, UIImage image, IBeaconProximity proximity)
		{
			Frame = new RectangleF (5, y, 300, 400);
			BackgroundColor = UIColor.White;

			titleFrame = new UILabel (new RectangleF (0, 50, Frame.Width, 30));
			titleFrame.Text = title;
			titleFrame.Font = UIFont.FromName ("Avenir Next", 16);
			titleFrame.TextAlignment = UITextAlignment.Center;

			
			headerFrame = new UILabel (new RectangleF (0, 10, Frame.Width, 30));
			headerFrame.Text = header;
			headerFrame.Text.ToUpper();
			headerFrame.Font = UIFont.FromName ("Avenir Next", 18);
			headerFrame.TextAlignment = UITextAlignment.Center;
			
			
			imageView = new UIImageView (new RectangleF (0, 100, Frame.Width, Frame.Width));
			imageView.Image = image;

			proximityContainer = new UIView (new RectangleF (75, 150 + Frame.Width, 400, 30));

			proximityView = new UIImageView (new RectangleF (0, 100 + Frame.Width, Frame.Width, 50));
			proximityView.Image = new UIImage("interest-bg.png");

			proximityLabel = new UILabel();
			proximityLabel.Text = "Your distance is:";
			proximityLabel.Font = UIFont.FromName ("Avenir Next", 14);

			preProximityLabel = new UILabel();
			preProximityLabel.Text = "Immediate";
			preProximityLabel.Font = UIFont.FromName ("Avenir Next", 14);

			proximityView.AddSubviews (preProximityLabel,proximityLabel);

			AddSubviews (titleFrame, headerFrame, imageView, proximityContainer, proximityView);
			

		}

		public void UpdateView()
		{
		}
	}
}

