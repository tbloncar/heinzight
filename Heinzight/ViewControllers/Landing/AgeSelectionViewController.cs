using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Heinzight.Core;

namespace Heinzight
{
	public delegate void OnAgeSelected(CurrentUser.AgeOptions age);

	public partial class AgeSelectionViewController : UIViewController
	{
		public event OnAgeSelected OnAgeSelected;

		public AgeSelectionViewController () : base ("AgeSelectionViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetCircleButtonDisplay (littleKidViewButton);
			SetCircleButtonDisplay (adultViewButton);

			var adultTapGesture = new UITapGestureRecognizer (OptionSelected(CurrentUser.AgeOptions.Adult));
			adultView.AddGestureRecognizer (adultTapGesture);

			var childTapGesture = new UITapGestureRecognizer (OptionSelected(CurrentUser.AgeOptions.Child));
			littleKidView.AddGestureRecognizer (childTapGesture);

		}

		static void SetCircleButtonDisplay(UIView v)
		{
			v.Layer.CornerRadius = 17;
			v.Layer.BorderColor = UIColor.LightGray.CGColor;
			v.BackgroundColor = UIColor.White;
			v.Layer.BorderWidth = 2.0f;
		}

		NSAction OptionSelected(CurrentUser.AgeOptions age) 
		{
			CurrentUser.Instance.Age = age;
			OnAgeSelected (age);
			return null;
		}
	}
}

