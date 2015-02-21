﻿
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
		List<Interest> userSelectedInterests = new List<Interest>();

		public InterestSelectionViewController () : base ("InterestSelectionViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			List<Interest> interests;
			using (var conn = Db.Instance.GetConnection ()) 
			{
				interests = conn.Table<Interest> ().ToList();
			}

			var lastY = 0f;
			foreach (var interest in interests) 
			{
				var interestButton =  CreateInterestButton (interest, lastY);
				interestsScrollView.Add (interestButton);
				lastY += interestButton.Frame.Height + PADDING_HEIGHT;
			}
		}

		UIView CreateInterestButton(Interest interest, float lastY)
		{
			var scrollViewFrame = interestsScrollView.Frame;

			var interestButton = new UIButton (new RectangleF (
				0, 
				lastY + PADDING_HEIGHT, 
				scrollViewFrame.Width,
				40
			));

			interestButton.Layer.BorderColor = UIColor.LightGray.CGColor;
			interestButton.Layer.BorderWidth = 2.0f;
			interestButton.Layer.CornerRadius = 20;
			interestButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			interestButton.SetTitle (interest.Name, UIControlState.Normal);
			interestButton.TouchUpInside += (sender, e) => InterestButtonToggle (interest, interestButton);
			return interestButton;
		}

		void InterestButtonToggle(Interest interest, UIButton button)
		{
			if (userSelectedInterests.Contains (interest)) 
			{
				userSelectedInterests.Remove (interest);
				button.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
				button.BackgroundColor = UIColor.White;
				button.Layer.BorderColor = UIColor.LightGray.CGColor;
			} 
			else 
			{
				userSelectedInterests.Add (interest);
				button.SetTitleColor (UIColor.White, UIControlState.Normal);
				button.BackgroundColor = UIColor.DarkGray;
				button.Layer.BorderColor = UIColor.DarkGray.CGColor;
			}

			continueButton.Visible = userSelectedInterests.Count != 0;
		}
	}
}

