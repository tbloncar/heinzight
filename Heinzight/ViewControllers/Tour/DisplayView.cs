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
			Frame = new RectangleF (4, y, 300, 400);
			BackgroundColor = UIColor.White;

			titleFrame = new UILabel (new RectangleF (0, 35, Frame.Width, 30));
			titleFrame.Text = title;
			titleFrame.Font = UIFont.FromName ("Avenir Next", 16);
			titleFrame.TextAlignment = UITextAlignment.Center;

			
			headerFrame = new UILabel (new RectangleF (0, 10, Frame.Width, 30));
			headerFrame.Text = header;
			headerFrame.Text.ToUpper();
			headerFrame.Font = UIFont.FromName ("Avenir Next", 18);
			headerFrame.TextAlignment = UITextAlignment.Center;
			
			
			imageView = new UIImageView (new RectangleF (15, 70, Frame.Width-30, Frame.Width-30));
			imageView.Image = image;

			proximityContainer = new UIView (new RectangleF (20, Frame.Width, 400, 30));

			proximityView = new UIImageView (new RectangleF (2, Frame.Width + 42, Frame.Width - 5, 55));
			proximityLabel = new UILabel();
			proximityLabel.Font = UIFont.FromName ("Avenir Next", 14);

			if (proximity == IBeaconProximity.Far) {
				proximityView.Image = UIImage.FromBundle ("meter-far.png");
				proximityLabel.Text = "FAR";
			}else if (proximity == IBeaconProximity.Near) {
				proximityView.Image = UIImage.FromBundle ("meter-close.png");
				proximityLabel.Text = "NEAR";
			}else if (proximity == IBeaconProximity.Immediate) {
				proximityView.Image = UIImage.FromBundle ("meter-immediate.png");
				proximityLabel.Text = "IMMEDIATE";
			}

			preProximityLabel = new UILabel();
			preProximityLabel.Text = "Your distance is:";
			preProximityLabel.Font = UIFont.FromName ("Avenir Next", 14);

			proximityContainer.AddSubviews (preProximityLabel,proximityLabel);

			AddSubviews (titleFrame, headerFrame, imageView, proximityContainer, proximityView);
			

		}

		public void UpdateView()
		{
		}
	}
}

